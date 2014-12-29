using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// look for TextBox Watermark

namespace Draco_RegexTest
{

    /// <summary>
    /// Primary form
    /// Data sources for DataGridViews: 
    ///    dTMatchesDataItemBindingSource
    ///    dTRegexItemBindingSource
    /// </summary>
    public partial class Draco_RegexTestForm : Form
    {
        private DTRegexManagerController mRegexWorkManager;
        private Color mMatchColor;
        private int mSourceSearchIndex;
        private string mLastSourceSearchMatchString;

        public Draco_RegexTestForm()
        {
            InitializeComponent();
            this.urlTextBox.SetWatermark("URL");
            EnableAll(false);
            this.startupBackgroundWorker.RunWorkerAsync();
            mMatchColor = Color.Green;
        }

        #region background workers

        private void startupBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Init();
        }

        private void startupBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DTRegexItem[] items = mRegexWorkManager.RegexWorkItems;
            this.dTRegexItemBindingSource.DataSource = items;
            EnableAll(true);
        }

        private void regexMatchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            mRegexWorkManager.FindMatchesForCurrentRegexString();
        }

        private void regexMatchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] captureNames = null;
            this.groupComboBox.Text = "";
            this.groupComboBox.Items.Add("");
            this.groupComboBox.Items.AddRange(mRegexWorkManager.GroupNamesInCurrentRegex());
            UpdateMatchesForCaptureNames(captureNames);
        }

        private void urlFetchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string urlString = e.Argument as string;
            if (urlString != null)
            {
                e.Result = new System.Net.WebClient().DownloadString(urlString);
            }
        }

        private void urlFetchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string sourceText = e.Result as string;
            if (sourceText != null)
            {
                this.sourceTextBox.Text = sourceText;
            }
        }

        #endregion

        #region controllers actions

        private void AddRegexToListButton_Click(object sender, EventArgs e)
        {
            if (this.regexEditTextBox.Text.Length > 0)
            {
               int addOK = mRegexWorkManager.CreateNewRegexItem("", this.regexEditTextBox.Text, DTRegexItemPurposeType.PrimaryUserCreated);
                if (addOK >= 0) 
                {
                    mRegexWorkManager.SaveStore();
                    DTRegexItem[] items = mRegexWorkManager.RegexWorkItems;
                    this.dTRegexItemBindingSource.DataSource = items;
                }
            } 
            
        }

        private void regexEditCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.regexEditCheckBox.Checked)
            {
                this.ClearDataGridChecksExcept(-1);

                this.regexEditTextBox.Text = StripNewLinesAndTabs(this.regexEditTextBox.Text);
                int checkRes = FindRegexMatchWork(this.regexEditTextBox.Text, this.sourceTextBox.Text);
                if (checkRes < 0)
                {
                    // report problem with regex string and disable checkbox

                    this.regexEditCheckBox.Checked = false;
                }
            }
            else
            {
                ClearMatches();
            }
        }

        private void regexEditTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.regexEditCheckBox.Checked)
            {
                int checkRes = FindRegexMatchWork(this.regexEditTextBox.Text, this.sourceTextBox.Text);
                if (checkRes < 0)
                {
                    // report problem with regex string and disable checkbox

                    this.regexEditCheckBox.Checked = false;
                }
            }
        }

        private void regexEditTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // multi-line disables default CTL+A selection
            if (e.Control && e.KeyCode == Keys.A)
            {
                regexEditTextBox.SelectAll();
            }
        }

        private void urlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.sourceTextBox.Text = "";
                this.urlFetchBackgroundWorker.RunWorkerAsync(this.urlTextBox.Text);
            }
        }

        private void sourceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // multi-line disables ctl+a selection
            if (e.Control && e.KeyCode == Keys.A)
            {
                sourceTextBox.SelectAll();
            }
        }

        private void escapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regexEditTextBox.Text = regexEditTextBox.Text.Replace("\\\\", "\\");
        }

        private void escapeescapeitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regexEditTextBox.Text = regexEditTextBox.Text.Replace("\\", "\\\\");
        }

        private void grabSourceSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cleanedText = CleanText(this.sourceTextBox.SelectedText);

            this.regexEditTextBox.Text = this.regexEditTextBox.Text.Insert(this.regexEditTextBox.SelectionStart, cleanedText);
        }

        private void nextSearchButton_Click(object sender, EventArgs e)
        {
            ColorSourceTextForLastSearchText(Color.Black);
            if (mLastSourceSearchMatchString != null && mLastSourceSearchMatchString.Length > 0)
            {
                mSourceSearchIndex = mSourceSearchIndex + mLastSourceSearchMatchString.Length;
            }
            else
            {
                mSourceSearchIndex = 0;
            }
            if (this.searchTextBox.Text.Length > 0)
            {
                SearchSourceText(this.searchTextBox.Text);
            }
        }

        private void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            
            TextBox tbox = sender as TextBox;
            /*
            if (tbox.Text == "")
            {
                string waterMarkText = "";
                if (tbox.Equals(this.urlTextBox))
                {
                    waterMarkText = "URL";
                }
                else if (tbox.Equals(this.regexEditTextBox))
                {
                    waterMarkText = "Regular Expression";
                }
                
            } */

            if (tbox.Equals(this.searchTextBox))
            {
                if (tbox.Text.Length == 0)
                {
                    ClearLastSearchMatch();
                    mSourceSearchIndex = 0;
                }
                else
                {
                    SearchSourceText(tbox.Text);
                }
            }
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.groupComboBox.Text.Length > 0)
            {
                string[] captureNames = new string[1];
                captureNames[0] = this.groupComboBox.Text;
                UpdateMatchesForCaptureNames(captureNames);
            }
            else
            {
                UpdateMatchesForCaptureNames(null);
            }
        }

        #endregion

        #region private methods

        private void Init()
        {
            mRegexWorkManager = new DTRegexManagerController();
        }

        private void EnableAll(bool enable)
        {
            this.regexDataGridView.Enabled = enable;
            this.regexEditCheckBox.Enabled = enable;
            this.regexEditTextBox.Enabled = enable;
            this.matchesDataGridView.Enabled = enable;
            this.sourceTextBox.Enabled = enable;
            this.urlTextBox.Enabled = enable;
        }

        private void ClearSourceTextColors()
        {
            this.sourceTextBox.SelectAll();
            this.sourceTextBox.SelectionColor = Color.Black;
            if (mLastSourceSearchMatchString != null && mLastSourceSearchMatchString.Length > 0)
            {
                SearchSourceText(mLastSourceSearchMatchString);
            }
            this.sourceTextBox.SelectionStart = 0;
            this.sourceTextBox.SelectionLength = 0;
        }

        private void ClearMatches()
        {
            this.dTMatchesDataItemBindingSource.DataSource = null;
            this.matchShowLimitTextBox.Text = "0";
            this.totalMatchesTextBox.Text = "0";
            this.groupComboBox.Items.Clear();
            this.groupComboBox.Text = "";
            ClearSourceTextColors();
        }

        private string CleanText(string text)
        {
            string result = mRegexWorkManager.SimplifyAndEscapeText(text);
            result = StripNewLinesAndTabs(result);

            return result;
        }

        private void ClearDataGridChecksExcept(int noClearIndex)
        {
            DataGridViewRowCollection rowCollection = this.regexDataGridView.Rows;
           
            for (int i = 0; i < rowCollection.Count; ++i)
            {
                if (i != noClearIndex)
                {
                    rowCollection[i].Cells[1].Value = false;
                }
            }
        }

        private void ColorSourceTextForMatch(DTMatchesDataItem matchItem, Color color)
        {
            if (matchItem.MatchIndex >= 0)
            {
                this.sourceTextBox.SelectionStart = matchItem.MatchIndex;
                this.sourceTextBox.SelectionLength = matchItem.MatchLength;
                this.sourceTextBox.SelectionColor = color;
            }
        }

        private void ColorSourceTextForLastSearchText(Color color)
        {
            if (mLastSourceSearchMatchString != null && mLastSourceSearchMatchString.Length > 0)
            {
                this.sourceTextBox.SelectionStart = mSourceSearchIndex;
                this.sourceTextBox.SelectionLength = mLastSourceSearchMatchString.Length;
                this.sourceTextBox.SelectionColor = color;
                this.sourceTextBox.ScrollToCaret();
            }
        }

        private void ClearLastSearchMatch()
        {
            ColorSourceTextForLastSearchText(Color.Black);
            mLastSourceSearchMatchString = "";
        }

        /// <summary>
        /// prechecks the term and starts bg worker if OK
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="regexPattern">1 if worker started, negative if failed precheck at text index, 0 if worker busy</param>
        private int FindRegexMatchWork(string regexPattern, string sourceText)
        {
            if (this.regexMatchBackgroundWorker.IsBusy) return 0;
            ClearMatches();

            int precheck = mRegexWorkManager.PreCheckRegexString(regexPattern);
            if (precheck > 0)
            {
                mRegexWorkManager.CurrentRegexString = regexPattern;
                mRegexWorkManager.CurrentTextToMatch = sourceText;
                this.regexMatchBackgroundWorker.RunWorkerAsync();
            }
            
            return precheck;
        }

        private void SearchSourceText(string searchString)
        {
            ClearLastSearchMatch();
            string sourceText = this.sourceTextBox.Text;
            int indexMatch = sourceText.IndexOf(searchString, mSourceSearchIndex, StringComparison.CurrentCultureIgnoreCase);

            if (indexMatch >= 0)
            {
                mLastSourceSearchMatchString = searchString;
                mSourceSearchIndex = indexMatch;
                ColorSourceTextForLastSearchText(Color.Orange);

            }
            else if (mSourceSearchIndex > 0)
            {
                mSourceSearchIndex = 0;
                this.SearchSourceText(searchString);
            }
            else
            {
                mSourceSearchIndex = 0;
            }
        }

        private string StripNewLinesAndTabs(string text)
        {
            return text.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\v", "");
        }

        private void UpdateMatchesForCaptureNames(string[] captureNames)
        {
            DTMatchesDataItem[] matchItems = mRegexWorkManager.MatchesWorkResults(captureNames);
            if (matchItems != null)
            {
                this.totalMatchesTextBox.Text = matchItems.Length.ToString();
                if (matchItems.Length > 100)
                {
                    List<DTMatchesDataItem> tmpList = new List<DTMatchesDataItem>();
                    tmpList.AddRange(matchItems);
                    tmpList.RemoveRange(100, matchItems.Length - 100);
                    matchItems = tmpList.ToArray();
                }
                this.matchShowLimitTextBox.Text = matchItems.Length.ToString();
            }
            this.dTMatchesDataItemBindingSource.DataSource = matchItems;

            for (int i = 0; i < matchItems.Length; ++i)
            {
                ColorSourceTextForMatch(matchItems[i], mMatchColor);
            }

            if (mRegexWorkManager.LastErrorString.Length > 0)
            {
                ClearMatches();
                this.responseToolStripStatusLabel.Text = mRegexWorkManager.LastErrorString;
            }
            else this.responseToolStripStatusLabel.Text = "Ready";
        }

        #endregion

        #region regexDataGrid Events

        private void regexDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            mRegexWorkManager.SaveStore();
            if (e.ColumnIndex == 4)
            {
                DataGridViewRowCollection rowCollection = this.regexDataGridView.Rows;
                if ((bool)rowCollection[e.RowIndex].Cells[1].Value == true)
                {
                    string regexString = rowCollection[e.RowIndex].Cells[4].Value as string;
                    FindRegexMatchWork(regexString, this.sourceTextBox.Text);
                }
            }
        }

        private void regexDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewRowCollection rowCollection = this.regexDataGridView.Rows;
                if ((bool)rowCollection[e.RowIndex].Cells[1].Value == true)
                {
                    this.regexEditCheckBox.Checked = false;
                    this.ClearDataGridChecksExcept(e.RowIndex);

                    int checkRes = FindRegexMatchWork((string)rowCollection[e.RowIndex].Cells[4].Value, this.sourceTextBox.Text);
                }
                else
                {
                    ClearMatches();
                }
            }
        }

        private void regexDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (regexDataGridView.IsCurrentCellDirty)
            {
                regexDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void regexDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRowCollection rowCollection = this.regexDataGridView.Rows;
            string regexString = rowCollection[e.RowIndex].Cells[4].Value as string;
            this.regexEditTextBox.Text = this.regexEditTextBox.Text.Insert(this.regexEditTextBox.SelectionStart, regexString);
        }

        

        #endregion

        

        



    }
}
