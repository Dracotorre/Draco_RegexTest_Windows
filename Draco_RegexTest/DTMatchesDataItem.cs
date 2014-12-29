using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Draco_RegexTest
{
    /// <summary>
    /// can be used as a row in a DataGrid
    /// </summary>
    public class DTMatchesDataItem
    {
        private Match mRegexMatch;
        private int mId;
        private string[] mCaptureNamesToReturn;

        public DTMatchesDataItem(Match regexMatch, int id, string[] captureNamesToDisplay)
        {
            mId = id;
            mRegexMatch = regexMatch;
            mCaptureNamesToReturn = captureNamesToDisplay;
        }

        public string ID
        {
            get { return mId.ToString(); }
        }

        /// <summary>
        /// Group 0
        /// </summary>
        public string FullMatch
        {
            get { return CaptureForGroup(0); }
        }

        /// <summary>
        /// or capture name at index 0 if using capture names
        /// </summary>
        public string GroupOne
        {
            get { return CaptureForGroup(1); }
        }

        public string GroupTwo
        {
            get { return CaptureForGroup(2); }
        }

        public string GroupThree
        {
            get { return CaptureForGroup(3); }
        }

        public string GroupFour
        {
            get { return CaptureForGroup(4);  }
        }

        public int MatchIndex
        {
            get { if (mRegexMatch != null) return mRegexMatch.Index; return -1; }
        }

        public int MatchLength
        {
            get { if (mRegexMatch != null) return mRegexMatch.Length; return 0; }
        }

        /// <summary>
        /// set to return regex capture names for GroupOne - GroupFour instead
        /// </summary>
        /// <param name="captureNames">may be null or empty to reset go group names</param>
        /// <returns></returns>
        public int SetCaptureGroupNames(string[] captureNames)
        {
            mCaptureNamesToReturn = captureNames;
            return 0;
        }

        private string CaptureForGroup(int groupNum)
        {
            if (mRegexMatch == null || mRegexMatch.Groups.Count < groupNum) return "";
            if (groupNum <= 0) return mRegexMatch.Groups[0].Value;

            if (mCaptureNamesToReturn != null && mCaptureNamesToReturn.Length > 0)
            {
                if (mCaptureNamesToReturn.Length >= groupNum)
                {
                    return mRegexMatch.Groups[mCaptureNamesToReturn[groupNum - 1]].Value;
                }
                return "";
            }
            return mRegexMatch.Groups[groupNum].Value;
        }




    }
}
