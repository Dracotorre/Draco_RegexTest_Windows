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

        public Draco_RegexTestForm()
        {
            InitializeComponent();
            this.urlTextBox.SetWatermark("URL");
            EnableAll(false);
            this.startupBackgroundWorker.RunWorkerAsync();
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

            if (mRegexWorkManager.LastErrorString.Length > 0)
            {
                ClearMatches();
                this.responseToolStripStatusLabel.Text = mRegexWorkManager.LastErrorString;
            }
            else this.responseToolStripStatusLabel.Text = "Ready";
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

        private void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            /*
            TextBox tbox = sender as TextBox;
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

        private void ClearMatches()
        {
            this.dTMatchesDataItemBindingSource.DataSource = null;
            this.matchShowLimitTextBox.Text = "0";
            this.totalMatchesTextBox.Text = "0";
        }

        private string CleanText(string text)
        {
            string result = StripNewLinesAndTabs(text);
            result = mRegexWorkManager.SimplifyAndEscapeText(result);
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

        private string StripNewLinesAndTabs(string text)
        {
            return text.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\v", "");
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
