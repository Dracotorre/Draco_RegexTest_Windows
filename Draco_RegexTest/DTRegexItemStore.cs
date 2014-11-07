using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Draco_RegexTest
{
    /// <summary>
    /// "There can be only one" item store - used by the main controller 
    /// Create new item here in CreateNewItem()
    /// Loads all items on init
    /// Assumption: small data size
    /// using XML for storage
    /// </summary>
    public class DTRegexItemStore
    {
        private List<DTRegexItem> mItems;
        private List<DTRegexItem> mInternalItems;

        private string mFilePath;

        /// <summary>
        /// for convenience, also see ItemsWithPurpose
        /// </summary>
        public DTRegexItem[] AllUserItems
        {
            get { return mItems.ToArray(); }
        }

        #region "constructor"

        public DTRegexItemStore(string filepathOfStore)
        {
            mFilePath = filepathOfStore;
            mInternalItems = new List<DTRegexItem>();
            LoadInternalItems();
            mItems = new List<DTRegexItem>();
            LoadItems();
        }

        #endregion

        #region "public methods"

        /// <summary>
        /// create an empty user-generated item
        /// </summary>
        /// <returns></returns>
        public DTRegexItem CreateNewItem()
        {
            DTRegexItem item = new DTRegexItem();
            mItems.Add(item);
            return item;
        }

        /// <summary>
        /// will not duplicate same title and regexString
        /// </summary>
        /// <param name="title"></param>
        /// <param name="regexString"></param>
        /// <param name="purpose"></param>
        /// <returns>returns created item or existing item</returns>
        public DTRegexItem CreateNewItem(string title, string regexString, DTRegexItemPurposeType purpose)
        {
            DTRegexItem item = new DTRegexItem(title, regexString, purpose);
            bool found = false;

            if (purpose == DTRegexItemPurposeType.InternalOnly)
            {
                for (int i = 0; i < mInternalItems.Count; ++i)
                {
                    if (mInternalItems[i].Equals(item))
                    {
                        item = mInternalItems[i];
                        found = true;
                    }
                }
                if (!found)
                {
                    mInternalItems.Add(item);
                }
            }
            else
            {
                for (int i = 0; i < mItems.Count; ++i)
                {
                    if (mItems[i].Equals(item))
                    {
                        item = mItems[i];
                        found = true;
                    }
                }
                if (!found)
                {
                    mItems.Add(item);
                }
            }

            return item;
        }

        public int RemoveItem(DTRegexItem item)
        {
            // use key to match
            for (int i = 0; i < mItems.Count; ++i)
            {
                if (mItems[i].ItemKey == item.ItemKey)
                {
                    mItems.RemoveAt(i);
                    break;
                }
            }
            return mItems.Count;
        }

        public DTRegexItem[] ItemsWithPurpose(DTRegexItemPurposeType purpose)
        {
            List<DTRegexItem> result = new List<DTRegexItem>();
            if (purpose == DTRegexItemPurposeType.InternalOnly)
            {
                result.AddRange(mInternalItems.ToArray());
            }
            else
            {
                foreach (DTRegexItem item in mItems)
                {
                    if (item.PurposeType == purpose)
                    {
                        result.Add(item);
                    }
                }
            }
            
            return result.ToArray();
        }

        public int Save()
        {
            return SaveItems();
        }

        #endregion

        #region "private methods"

        private int LoadItems()
        {
            mItems.Clear();
            mItems.AddRange(LoadItemsFromFile(mFilePath));
            if (mItems.Count == 0)
            {
                // add favorite clips and helpers
                string fileName = System.IO.Path.Combine("Resources", "basicRegex.xml");
                string favFile = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, fileName);
                mItems.AddRange(LoadItemsFromFile(favFile));
            }
            return 0;
        }

        private int LoadInternalItems()
        {
            mInternalItems.Clear();
            string fileName = System.IO.Path.Combine("Resources", "internItemsRegex.xml");
            string filepath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, fileName);
            mInternalItems.AddRange(LoadItemsFromFile(filepath));

            System.Diagnostics.Debug.WriteLine("loaded internals: " + mInternalItems.Count.ToString());
            return 0;
        }

        private List<DTRegexItem> LoadItemsFromFile(string filepath)
        {
            List<DTRegexItem> items = new List<DTRegexItem>();
            if (System.IO.File.Exists(filepath))
            {
                using (System.IO.FileStream reader = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (XmlReader xReader = XmlReader.Create(reader))
                    {
                        while(xReader.Read())
                        {
                            if (xReader.NodeType == XmlNodeType.Element && xReader.Name.Equals("dtr_item"))
                            {
                                if (xReader.HasAttributes)
                                {
                                    string key = xReader.GetAttribute("key");
                                    string purposeString = xReader.GetAttribute("purpose");
                                    string title = xReader.GetAttribute("title");
                                    string regexStr = xReader.GetAttribute("regex");
                                    if (purposeString.Length > 0 && regexStr.Length > 0)
                                    {
                                        DTRegexItemPurposeType purpose = (DTRegexItemPurposeType)Enum.Parse(typeof(DTRegexItemPurposeType), purposeString);
                                        DTRegexItem item = new DTRegexItem(title, regexStr, purpose, key);
                                        items.Add(item);
                                    }
                                }
                            }
                        }
                    }
                }
                items.Sort();
            }
            
            return items;
        }

        private int SaveItems()
        {
            using (System.IO.FileStream writer = new System.IO.FileStream(mFilePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            {
                using (XmlWriter xWriter = XmlWriter.Create(writer))
                {
                    xWriter.WriteStartDocument(false);
                    xWriter.WriteStartElement("DTRegexItems");

                    // for each
                    foreach (DTRegexItem item in mItems)
                    {
                        if (item.RegexString.Length > 0)
                        {
                            xWriter.WriteStartElement("dtr_item");
                            xWriter.WriteAttributeString("key", item.ItemKey);
                            xWriter.WriteAttributeString("purpose", Enum.GetName(typeof(DTRegexItemPurposeType), item.PurposeType));
                            xWriter.WriteAttributeString("title", item.Title);
                            xWriter.WriteAttributeString("regex", item.RegexString);
                            xWriter.WriteEndElement();
                        }
                    }

                    xWriter.WriteEndElement();
                    xWriter.WriteEndDocument();

                    xWriter.Flush();
                    xWriter.Close();
                }
                writer.Flush();
                writer.Close();
            }

            return 0;
        }

        #endregion
    }
}
