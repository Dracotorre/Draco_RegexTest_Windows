using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draco_RegexTest
{
    public enum DTRegexItemPurposeType
    {
        PrimaryUserCreated,
        FavoriteClip,
        /// <summary>
        /// helpers for Regex work
        /// </summary>
        MachineHelp,
        /// <summary>
        /// not stored in user file
        /// </summary>
        InternalOnly
    };

    /// <summary>
    /// An item of named regular expression string for a purpose.
    /// 2 items are considered the same if both have same regexString, purpose, and title - ItemKey not considered.
    /// </summary>
    public class DTRegexItem : IComparable<DTRegexItem>
    {
        DTRegexItemPurposeType mPurpose;
        public DTRegexItemPurposeType PurposeType { get { return mPurpose; } }

        private string mItemKey;
        public string ItemKey
        {
            get { return mItemKey; }
        }

        private string mTitle;
        public string Title
        {
            get { if (mTitle == null) return ""; return mTitle; }
            set { mTitle = value; }
        }

        private string mRegexString;
        public string RegexString
        {
            get { if (mRegexString == null) return ""; return mRegexString; }
            set { mRegexString = value; }
        }

        public bool IsChecked { get; set; }

        #region "constructors"

        /// <summary>
        /// primary constructor for new user-created standard regular expressions
        /// </summary>
        /// <param name="title"></param>
        /// <param name="regexString"></param>
        public DTRegexItem(string title, string regexString)
        {
            this.Init(title, regexString, DTRegexItemPurposeType.PrimaryUserCreated);
        }

        /// <summary>
        /// secondary constructor for new expression with a purpose
        /// </summary>
        /// <param name="title"></param>
        /// <param name="regexString"></param>
        /// <param name="purpose"></param>
        public DTRegexItem(string title, string regexString, DTRegexItemPurposeType purpose)
        {
            this.Init(title, regexString, purpose);
        }

        /// <summary>
        /// constructor generally used for loading existing data
        /// </summary>
        /// <param name="title"></param>
        /// <param name="regexString"></param>
        /// <param name="purpose"></param>
        /// <param name="key">item key (unique)</param>
        public DTRegexItem(string title, string regexString, DTRegexItemPurposeType purpose, string key)
        {
            this.Init(title, regexString, purpose, key);
        }

        /// <summary>
        /// creates a new empty item. see other constructors
        /// </summary>
        public DTRegexItem()
        {
            this.Init("", "", DTRegexItemPurposeType.PrimaryUserCreated);
        }

        #endregion

        #region "IComparable"

        public int CompareTo(DTRegexItem other)
        {
            return this.CompareCheck(other);
        }

        public int CompareTo(object otherObj)
        {
            DTRegexItem other = otherObj as DTRegexItem;
            if ((System.Object)other != null)
            {
                return this.CompareCheck(other);
            }
            return -1;
        }

        #endregion

        #region "overrides and overloads"

        public bool Equals(DTRegexItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.PurposeType.Equals(other.PurposeType) && 
                this.Title.Equals(other.Title) &&
                this.RegexString.Equals(other.RegexString);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(DTRegexItem)) return false;
            return this.Equals(obj as DTRegexItem);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return mPurpose.GetHashCode() ^ 
                    ((mRegexString != null ? mRegexString.GetHashCode() : 0) * 19) ^ 
                    (mTitle != null ? mTitle.GetHashCode() : 0);
            }
        }

        public static bool operator ==(DTRegexItem left, DTRegexItem right)
        {
            if (System.Object.ReferenceEquals(left, right)) return true;

            if (ReferenceEquals(null, left) || ReferenceEquals(null, right)) return false;

            return left.PurposeType == right.PurposeType && 
                left.Title == right.Title && 
                left.RegexString == right.RegexString;
        }

        public static bool operator !=(DTRegexItem left, DTRegexItem right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return mTitle + " (" + mPurpose.ToString() +") " + " - " + mRegexString;
        }

        #endregion

        #region "private methods"
   
        private void Init(string title, string regexString, DTRegexItemPurposeType purpose, string key = "")
        {
            mPurpose = purpose;
            mTitle = title;
            mRegexString = regexString;
            if (key == null || key.Length == 0)
            {
                mItemKey = System.Guid.NewGuid().ToString();
            }
            else mItemKey = key; 
        }

        private int CompareCheck(DTRegexItem other)
        {
            if (other != null)
            {
                if (this.Title.Equals(other.Title))
                {
                    if (this.RegexString.Equals(other.RegexString))
                    {
                        this.PurposeType.CompareTo(other.PurposeType);
                    }
                }
                else return this.Title.CompareTo(other.Title);
            }
            return -1;
        }
        #endregion
    }
}
