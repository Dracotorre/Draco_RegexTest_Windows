using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Draco_RegexTest
{
    /// <summary>
    /// performs the work for matching, safety checking before matching, and access to the store
    /// </summary>
    public class DTRegexManagerController
    {
        private DTRegexItemStore mItemStore;   // the only instance in app
        private MatchCollection mLastMatches;
        private string mLastRegexString;
        private string mLastErrorString;
        private string mCurrentRegexString;
        private string mCurrentText;
        private string mFilePathOfUserStore;
        private bool mWorking;
        
        /// <summary>
        /// inits with previous user records. recommend run in background worker
        /// </summary>
        public DTRegexManagerController()
        {
            mFilePathOfUserStore = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DracoRegex.xml");
            mLastMatches = null;
            mLastRegexString = "";
            mLastErrorString = "";
            LoadItems();
        }

        #region properties


        /// <summary>
        /// if busy working then RegexStringWork and MatchesWorkResults not updated yet
        /// </summary>
        public bool IsWorking { get { return mWorking; } }

        /// <summary>
        /// for using with FindMatchesForCurrentRegexString
        /// </summary>
        public string CurrentRegexString
        {
            get { return mCurrentRegexString; }
            set
            {
               if (value == null) mCurrentRegexString = "";
               mCurrentRegexString = value;
            }
        }

        /// <summary>
        /// text to find matches with CurrentRegexString with FindMatchesForCurrentRegexString
        /// </summary>
        public string CurrentTextToMatch
        {
            get { return mCurrentText; }
            set
            {
                if (value == null) mCurrentText = "";
                mCurrentText = value;
            }
        }

        public string LastRegexStringWork
        {
            get { return mLastRegexString;  }
        }

        public string LastErrorString
        {
            get { return mLastErrorString; }
        }

        public string ReduceSpacingFromText(string text)
        {
            string result = Regex.Replace(text, "\\b[\\s\\n\\r\\t]+?\\b", "\\s+", RegexOptions.None);

            return result;
        }

        /// <summary>
        /// regex strings and clips created by the user
        /// </summary>
        public DTRegexItem[] RegexWorkItems
        {
            get { return mItemStore.AllUserItems; }
        }

        public DTRegexItem[] RegexInternalItems
        {
            get { return mItemStore.ItemsWithPurpose(DTRegexItemPurposeType.InternalOnly); }
        }

        public DTRegexItem[] RegexHelperItems
        {
            get { return mItemStore.ItemsWithPurpose(DTRegexItemPurposeType.MachineHelp); }
        }

        #endregion

        #region public methods

        public int CreateNewRegexItem(string title, string regexString, DTRegexItemPurposeType purpose)
        {
            DTRegexItem[] items = mItemStore.AllUserItems;
            for (int i = 0; i < items.Length; ++i)
            {
                if (items[i].RegexString.Equals(regexString))
                {
                    return -1;
                }
            }
            DTRegexItem newItem = mItemStore.CreateNewItem("", regexString, purpose);



            return 1;
        }

        /// <summary>
        /// finds all the capture group names within regular expression
        /// </summary>
        /// <returns></returns>
        public string[] GroupNamesInCurrentRegex()
        {
            List<string> captureNames = new List<string>();
            if (mCurrentRegexString != null)
            {
                int indexOfStart = mCurrentRegexString.IndexOf("(?<");
                while (indexOfStart >= 0 && indexOfStart < mCurrentRegexString.Length)
                {
                    int indexOfNextParen = mCurrentRegexString.IndexOf(">", indexOfStart);
                    if (indexOfNextParen > indexOfStart + 3)
                    {
                        string groupName = mCurrentRegexString.Substring(indexOfStart + 3, indexOfNextParen - 3 - indexOfStart);
                        captureNames.Add(groupName);
                        indexOfStart = mCurrentRegexString.IndexOf("(?<", indexOfNextParen + 1);
                    }
                    else indexOfStart = -2;
                }
            }
            return captureNames.ToArray();
        }

        /// <summary>
        /// results of FindMatchesForCurrentRegexString
        /// </summary>
        /// <param name="captureGroupNamesToDisplay">may be null</param>
        /// <returns></returns>
        public DTMatchesDataItem[] MatchesWorkResults(string[] captureGroupNamesToDisplay)
        {
            List<DTMatchesDataItem> resultMatches = new List<DTMatchesDataItem>();
            if (mLastMatches != null)
            {
                for (int i = 0; i < mLastMatches.Count; ++i)
                {
                    DTMatchesDataItem item = new DTMatchesDataItem(mLastMatches[i], resultMatches.Count, captureGroupNamesToDisplay);
                    resultMatches.Add(item);
                }
            }

            return resultMatches.ToArray();
        }
       
        /// <summary>
        /// updates MatchWorkResults based on CurrenRegexString and CurrenTextToMatch -- test with PreCheckRegexString first
        /// not threaded, run in background worker
        /// </summary>
        /// <returns></returns>
        public int FindMatchesForCurrentRegexString()
        {
            if (mWorking) return -2;
            int result = 0;
            if (mCurrentRegexString != null && mCurrentRegexString.Length > 0)
            {
                // update mCurrentRegexString after matches finish so CurrentRegex and CurrentMatches are in sync with last update
                mWorking = true;
                mLastErrorString = "";
                if (mCurrentText != null)
                {
                    try
                    {
                        MatchCollection matches = Regex.Matches(mCurrentText, mCurrentRegexString);
                        mLastMatches = matches;

                    }
                    catch (ArgumentException ex)
                    {
                        mLastErrorString = ex.Message;
                        result = -3;
                    }
                    
                }
                else mLastMatches = null;

                mLastRegexString = String.Copy(mCurrentRegexString);
               
                mWorking = false;
                return result;
            }
            else
            {
                mLastMatches = null;
                mLastRegexString = "";
            }
            return -1;
        }

        /// <summary>
        /// checks for obvious problems in regex before matching to reduce chances of looping or very long matches
        /// 1 if safe to try matching
        /// </summary>
        /// <param name="regexString"></param>
        /// <returns>1 for pass, negative for fail at index (-1 is start of string)</returns>
        public int PreCheckRegexString(string regexString)
        {
            // keep reasonably fast looking for obvious issues
            if (CheckStartOfRegexString(regexString) < 0) return -1;
            int check = CheckForPatternDoublesInregexString(regexString);
            if (check < 0) return check;

            return 1;
        }

        public int SaveStore()
        {
            return mItemStore.Save();
        }

        /// <summary>
        /// turn source text into safe (escaped) regex string with some common regex shortcuts
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string SimplifyAndEscapeText(string text)
        {
            // step 1:
            string result = ReplaceCommonPatternsWithHolderStringsInText(text);

            // step 2: escape
            result = result.Replace("\\", "\\\\");
            result = result.Replace("?", "\\?").Replace("+", "\\+").Replace("*", "\\*").Replace("-", "\\-").Replace(".", "\\.").Replace("|", "\\|");
            result = result.Replace("(", "\\(").Replace(")", "\\)").Replace("{", "\\{").Replace("}", "\\}").Replace("[", "\\[").Replace("]", "\\]");

            // step 3
            result = ReduceSpacingFromText(result);

            // step 4: replace common numbers not replaced by common patterns
            result = ReplaceCommonNumberPatternsInText(result);

            // step 5:
            result = ReplaceHolderStringsWithRegexInText(result);

            return result;
        }

        #endregion

        #region private methods

        private int LoadItems()
        {
            mItemStore = new DTRegexItemStore(mFilePathOfUserStore);

            return 0;
        }

        /// <summary>
        /// common errors with bad doubled patterns causing major errors,
        /// not exhaustive
        /// </summary>
        /// <param name="regexString"></param>
        /// <returns></returns>
        private int CheckForPatternDoublesInregexString(string regexString)
        {
            int checkIt = PatternCheckNotEscaped("||", regexString, false);
            if (checkIt < 0) return checkIt;
            checkIt = PatternCheckNotEscaped("[\\W\\D\\S]*?[\\W\\D\\S]*?", regexString, false);
            return checkIt;
        }

        /// <summary>
        /// pattern should not start with
        /// </summary>
        /// <param name="regexString"></param>
        /// <returns>1 is OK</returns>
        private int CheckStartOfRegexString(string regexString)
        {
            if (regexString.StartsWith("?")) return -1;
            if (regexString.StartsWith("*")) return -1;
            if (regexString.StartsWith("!")) return -1;
            if (regexString.StartsWith("|")) return -1;
            if (regexString.StartsWith(")")) return -1;
            if (regexString.StartsWith("}")) return -1;
            if (regexString.StartsWith(".*")) return -1;  // help prevent bad habit
            if (regexString.StartsWith(".+")) return -1;
            if (regexString.StartsWith("[\\W\\D\\S]")) return -1;
            if (regexString.StartsWith("[\\D\\W\\S]") || regexString.StartsWith("[\\D\\S\\W]") || 
                regexString.StartsWith("[\\S\\W\\D]") || regexString.StartsWith("[\\S\\D\\W]"))
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// look for pattern and check if first char of pattern is escaped
        /// </summary>
        /// <param name="patternToFind"></param>
        /// <param name="regexString"></param>
        /// <param name="okAtStart"></param>
        /// <returns>0 or negative index unescaped pattern found</returns>
        private int PatternCheckNotEscaped(string patternToFind, string regexString, bool okAtStart)
        {
            int idx = regexString.IndexOf(patternToFind);
            if (idx == 0 && !okAtStart) return -1;
            else if (idx > 0)
            {
                if (!regexString[idx - 1].Equals('\\')) return -idx;
            }
            return 0;
        }

        private string ReplaceCommonPatternsWithHolderStringsInText(string text)
        {
            DTRegexItem[] commonPatternItems = mItemStore.ItemsWithPurpose(DTRegexItemPurposeType.InternalOnly);

            string result = text;

            if (commonPatternItems != null)
            {
                for (int i = 0; i < commonPatternItems.Length; ++i)
                {
                    if (Regex.IsMatch(result, commonPatternItems[i].RegexString))
                    {
                        result = Regex.Replace(result, commonPatternItems[i].RegexString, "~" + commonPatternItems[i].Title + "~");
                    }
                }
            }

            return result;
        }

        private string ReplaceCommonNumberPatternsInText(string text)
        {
            string result = Regex.Replace(text, "\\b\\d+\\b", "\\d+");

            return result;
        }

        private string ReplaceHolderStringsWithRegexInText(string text)
        {
            string result = text;
            DTRegexItem[] commonPatternItems = mItemStore.ItemsWithPurpose(DTRegexItemPurposeType.InternalOnly);

            if (commonPatternItems != null)
            {
                for (int i = 0; i < commonPatternItems.Length; ++i)
                {
                    string holder = "~" + commonPatternItems[i].Title + "~";
                    result = result.Replace(holder, commonPatternItems[i].RegexString);
                }
            }

            return result;
        }

        #endregion
    }
}
