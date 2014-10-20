namespace Draco_RegexTest
{
    partial class Draco_RegexTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMainLR = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeftSide = new System.Windows.Forms.SplitContainer();
            this.splitContainerEditor = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelRegexEdit = new System.Windows.Forms.TableLayoutPanel();
            this.regexEditCheckBox = new System.Windows.Forms.CheckBox();
            this.AddRegexToListButton = new System.Windows.Forms.Button();
            this.regexEditTextBox = new System.Windows.Forms.TextBox();
            this.regexDataGridView = new System.Windows.Forms.DataGridView();
            this.ItemKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.purposeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regexStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTRegexItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainerRegexResults = new System.Windows.Forms.SplitContainer();
            this.matchShowLimitTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.totalMatchesTextBox = new System.Windows.Forms.TextBox();
            this.totalMatchLabel = new System.Windows.Forms.Label();
            this.matchesDataGridView = new System.Windows.Forms.DataGridView();
            this.matchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullMatchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupOneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTwoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupThreeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupFourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTMatchesDataItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanelSource = new System.Windows.Forms.TableLayoutPanel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escapeescapeitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grabSourceSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.responseToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.startupBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.regexMatchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.urlFetchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.sourceTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLR)).BeginInit();
            this.splitContainerMainLR.Panel1.SuspendLayout();
            this.splitContainerMainLR.Panel2.SuspendLayout();
            this.splitContainerMainLR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftSide)).BeginInit();
            this.splitContainerLeftSide.Panel1.SuspendLayout();
            this.splitContainerLeftSide.Panel2.SuspendLayout();
            this.splitContainerLeftSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditor)).BeginInit();
            this.splitContainerEditor.Panel1.SuspendLayout();
            this.splitContainerEditor.Panel2.SuspendLayout();
            this.splitContainerEditor.SuspendLayout();
            this.tableLayoutPanelRegexEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regexDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTRegexItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRegexResults)).BeginInit();
            this.splitContainerRegexResults.Panel1.SuspendLayout();
            this.splitContainerRegexResults.Panel2.SuspendLayout();
            this.splitContainerRegexResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTMatchesDataItemBindingSource)).BeginInit();
            this.tableLayoutPanelSource.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMainLR
            // 
            this.splitContainerMainLR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMainLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainLR.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMainLR.Name = "splitContainerMainLR";
            // 
            // splitContainerMainLR.Panel1
            // 
            this.splitContainerMainLR.Panel1.Controls.Add(this.splitContainerLeftSide);
            // 
            // splitContainerMainLR.Panel2
            // 
            this.splitContainerMainLR.Panel2.Controls.Add(this.tableLayoutPanelSource);
            this.splitContainerMainLR.Size = new System.Drawing.Size(1035, 650);
            this.splitContainerMainLR.SplitterDistance = 567;
            this.splitContainerMainLR.SplitterWidth = 12;
            this.splitContainerMainLR.TabIndex = 0;
            // 
            // splitContainerLeftSide
            // 
            this.splitContainerLeftSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerLeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeftSide.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeftSide.Name = "splitContainerLeftSide";
            this.splitContainerLeftSide.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeftSide.Panel1
            // 
            this.splitContainerLeftSide.Panel1.Controls.Add(this.splitContainerEditor);
            // 
            // splitContainerLeftSide.Panel2
            // 
            this.splitContainerLeftSide.Panel2.Controls.Add(this.splitContainerRegexResults);
            this.splitContainerLeftSide.Size = new System.Drawing.Size(567, 650);
            this.splitContainerLeftSide.SplitterDistance = 253;
            this.splitContainerLeftSide.SplitterWidth = 8;
            this.splitContainerLeftSide.TabIndex = 0;
            // 
            // splitContainerEditor
            // 
            this.splitContainerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerEditor.IsSplitterFixed = true;
            this.splitContainerEditor.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEditor.Name = "splitContainerEditor";
            this.splitContainerEditor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEditor.Panel1
            // 
            this.splitContainerEditor.Panel1.Controls.Add(this.tableLayoutPanelRegexEdit);
            // 
            // splitContainerEditor.Panel2
            // 
            this.splitContainerEditor.Panel2.Controls.Add(this.regexDataGridView);
            this.splitContainerEditor.Size = new System.Drawing.Size(563, 249);
            this.splitContainerEditor.SplitterDistance = 79;
            this.splitContainerEditor.TabIndex = 0;
            // 
            // tableLayoutPanelRegexEdit
            // 
            this.tableLayoutPanelRegexEdit.ColumnCount = 3;
            this.tableLayoutPanelRegexEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanelRegexEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRegexEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanelRegexEdit.Controls.Add(this.regexEditCheckBox, 0, 0);
            this.tableLayoutPanelRegexEdit.Controls.Add(this.AddRegexToListButton, 2, 0);
            this.tableLayoutPanelRegexEdit.Controls.Add(this.regexEditTextBox, 1, 0);
            this.tableLayoutPanelRegexEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRegexEdit.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRegexEdit.Name = "tableLayoutPanelRegexEdit";
            this.tableLayoutPanelRegexEdit.RowCount = 1;
            this.tableLayoutPanelRegexEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRegexEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanelRegexEdit.Size = new System.Drawing.Size(563, 79);
            this.tableLayoutPanelRegexEdit.TabIndex = 0;
            // 
            // regexEditCheckBox
            // 
            this.regexEditCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.regexEditCheckBox.AutoSize = true;
            this.regexEditCheckBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regexEditCheckBox.Location = new System.Drawing.Point(18, 32);
            this.regexEditCheckBox.Name = "regexEditCheckBox";
            this.regexEditCheckBox.Size = new System.Drawing.Size(15, 14);
            this.regexEditCheckBox.TabIndex = 0;
            this.regexEditCheckBox.UseVisualStyleBackColor = true;
            this.regexEditCheckBox.CheckedChanged += new System.EventHandler(this.regexEditCheckBox_CheckedChanged);
            // 
            // AddRegexToListButton
            // 
            this.AddRegexToListButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddRegexToListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRegexToListButton.Location = new System.Drawing.Point(502, 28);
            this.AddRegexToListButton.Name = "AddRegexToListButton";
            this.AddRegexToListButton.Size = new System.Drawing.Size(39, 23);
            this.AddRegexToListButton.TabIndex = 2;
            this.AddRegexToListButton.Text = "+";
            this.AddRegexToListButton.UseVisualStyleBackColor = true;
            this.AddRegexToListButton.Click += new System.EventHandler(this.AddRegexToListButton_Click);
            // 
            // regexEditTextBox
            // 
            this.regexEditTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regexEditTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regexEditTextBox.Location = new System.Drawing.Point(39, 3);
            this.regexEditTextBox.Multiline = true;
            this.regexEditTextBox.Name = "regexEditTextBox";
            this.regexEditTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.regexEditTextBox.Size = new System.Drawing.Size(457, 73);
            this.regexEditTextBox.TabIndex = 1;
            this.regexEditTextBox.WordWrap = false;
            this.regexEditTextBox.TextChanged += new System.EventHandler(this.regexEditTextBox_TextChanged);
            this.regexEditTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.regexEditTextBox_KeyDown);
            // 
            // regexDataGridView
            // 
            this.regexDataGridView.AllowUserToAddRows = false;
            this.regexDataGridView.AllowUserToDeleteRows = false;
            this.regexDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regexDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.regexDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.regexDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.regexDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.regexDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemKey,
            this.CheckColumn,
            this.purposeTypeDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.regexStringDataGridViewTextBoxColumn});
            this.regexDataGridView.DataSource = this.dTRegexItemBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.regexDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.regexDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regexDataGridView.Location = new System.Drawing.Point(0, 0);
            this.regexDataGridView.Name = "regexDataGridView";
            this.regexDataGridView.Size = new System.Drawing.Size(563, 166);
            this.regexDataGridView.TabIndex = 0;
            this.regexDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.regexDataGridView_CellEndEdit);
            this.regexDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.regexDataGridView_CellValueChanged);
            this.regexDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.regexDataGridView_CurrentCellDirtyStateChanged);
            this.regexDataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.regexDataGridView_RowHeaderMouseDoubleClick);
            // 
            // ItemKey
            // 
            this.ItemKey.DataPropertyName = "ItemKey";
            this.ItemKey.HeaderText = "ItemKey";
            this.ItemKey.Name = "ItemKey";
            this.ItemKey.ReadOnly = true;
            this.ItemKey.Visible = false;
            this.ItemKey.Width = 6;
            // 
            // CheckColumn
            // 
            this.CheckColumn.DataPropertyName = "IsChecked";
            this.CheckColumn.HeaderText = "";
            this.CheckColumn.Name = "CheckColumn";
            this.CheckColumn.Width = 20;
            // 
            // purposeTypeDataGridViewTextBoxColumn
            // 
            this.purposeTypeDataGridViewTextBoxColumn.DataPropertyName = "PurposeType";
            this.purposeTypeDataGridViewTextBoxColumn.HeaderText = "PurposeType";
            this.purposeTypeDataGridViewTextBoxColumn.Name = "purposeTypeDataGridViewTextBoxColumn";
            this.purposeTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // regexStringDataGridViewTextBoxColumn
            // 
            this.regexStringDataGridViewTextBoxColumn.DataPropertyName = "RegexString";
            this.regexStringDataGridViewTextBoxColumn.HeaderText = "RegexString";
            this.regexStringDataGridViewTextBoxColumn.Name = "regexStringDataGridViewTextBoxColumn";
            this.regexStringDataGridViewTextBoxColumn.Width = 320;
            // 
            // dTRegexItemBindingSource
            // 
            this.dTRegexItemBindingSource.DataSource = typeof(Draco_RegexTest.DTRegexItem);
            // 
            // splitContainerRegexResults
            // 
            this.splitContainerRegexResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRegexResults.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerRegexResults.IsSplitterFixed = true;
            this.splitContainerRegexResults.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRegexResults.Name = "splitContainerRegexResults";
            this.splitContainerRegexResults.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRegexResults.Panel1
            // 
            this.splitContainerRegexResults.Panel1.Controls.Add(this.matchShowLimitTextBox);
            this.splitContainerRegexResults.Panel1.Controls.Add(this.label1);
            this.splitContainerRegexResults.Panel1.Controls.Add(this.groupComboBox);
            this.splitContainerRegexResults.Panel1.Controls.Add(this.totalMatchesTextBox);
            this.splitContainerRegexResults.Panel1.Controls.Add(this.totalMatchLabel);
            // 
            // splitContainerRegexResults.Panel2
            // 
            this.splitContainerRegexResults.Panel2.Controls.Add(this.matchesDataGridView);
            this.splitContainerRegexResults.Size = new System.Drawing.Size(563, 385);
            this.splitContainerRegexResults.SplitterDistance = 81;
            this.splitContainerRegexResults.TabIndex = 0;
            // 
            // matchShowLimitTextBox
            // 
            this.matchShowLimitTextBox.Location = new System.Drawing.Point(99, 48);
            this.matchShowLimitTextBox.Name = "matchShowLimitTextBox";
            this.matchShowLimitTextBox.ReadOnly = true;
            this.matchShowLimitTextBox.Size = new System.Drawing.Size(86, 20);
            this.matchShowLimitTextBox.TabIndex = 4;
            this.matchShowLimitTextBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Showing:";
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(375, 24);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(166, 21);
            this.groupComboBox.TabIndex = 2;
            // 
            // totalMatchesTextBox
            // 
            this.totalMatchesTextBox.Location = new System.Drawing.Point(99, 21);
            this.totalMatchesTextBox.Name = "totalMatchesTextBox";
            this.totalMatchesTextBox.ReadOnly = true;
            this.totalMatchesTextBox.Size = new System.Drawing.Size(86, 20);
            this.totalMatchesTextBox.TabIndex = 1;
            this.totalMatchesTextBox.Text = "0";
            // 
            // totalMatchLabel
            // 
            this.totalMatchLabel.AutoSize = true;
            this.totalMatchLabel.Location = new System.Drawing.Point(15, 24);
            this.totalMatchLabel.Name = "totalMatchLabel";
            this.totalMatchLabel.Size = new System.Drawing.Size(78, 13);
            this.totalMatchLabel.TabIndex = 0;
            this.totalMatchLabel.Text = "Total Matches:";
            // 
            // matchesDataGridView
            // 
            this.matchesDataGridView.AllowUserToAddRows = false;
            this.matchesDataGridView.AllowUserToDeleteRows = false;
            this.matchesDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.matchesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.matchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matchID,
            this.fullMatchDataGridViewTextBoxColumn,
            this.groupOneDataGridViewTextBoxColumn,
            this.groupTwoDataGridViewTextBoxColumn,
            this.groupThreeDataGridViewTextBoxColumn,
            this.groupFourDataGridViewTextBoxColumn});
            this.matchesDataGridView.DataSource = this.dTMatchesDataItemBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matchesDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.matchesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.matchesDataGridView.Name = "matchesDataGridView";
            this.matchesDataGridView.ReadOnly = true;
            this.matchesDataGridView.Size = new System.Drawing.Size(563, 300);
            this.matchesDataGridView.TabIndex = 0;
            // 
            // matchID
            // 
            this.matchID.DataPropertyName = "ID";
            this.matchID.HeaderText = "ID";
            this.matchID.Name = "matchID";
            this.matchID.ReadOnly = true;
            this.matchID.Width = 44;
            // 
            // fullMatchDataGridViewTextBoxColumn
            // 
            this.fullMatchDataGridViewTextBoxColumn.DataPropertyName = "FullMatch";
            this.fullMatchDataGridViewTextBoxColumn.HeaderText = "FullMatch";
            this.fullMatchDataGridViewTextBoxColumn.Name = "fullMatchDataGridViewTextBoxColumn";
            this.fullMatchDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullMatchDataGridViewTextBoxColumn.Width = 180;
            // 
            // groupOneDataGridViewTextBoxColumn
            // 
            this.groupOneDataGridViewTextBoxColumn.DataPropertyName = "GroupOne";
            this.groupOneDataGridViewTextBoxColumn.HeaderText = "GroupOne";
            this.groupOneDataGridViewTextBoxColumn.Name = "groupOneDataGridViewTextBoxColumn";
            this.groupOneDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupOneDataGridViewTextBoxColumn.Width = 120;
            // 
            // groupTwoDataGridViewTextBoxColumn
            // 
            this.groupTwoDataGridViewTextBoxColumn.DataPropertyName = "GroupTwo";
            this.groupTwoDataGridViewTextBoxColumn.HeaderText = "GroupTwo";
            this.groupTwoDataGridViewTextBoxColumn.Name = "groupTwoDataGridViewTextBoxColumn";
            this.groupTwoDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupTwoDataGridViewTextBoxColumn.Width = 120;
            // 
            // groupThreeDataGridViewTextBoxColumn
            // 
            this.groupThreeDataGridViewTextBoxColumn.DataPropertyName = "GroupThree";
            this.groupThreeDataGridViewTextBoxColumn.HeaderText = "GroupThree";
            this.groupThreeDataGridViewTextBoxColumn.Name = "groupThreeDataGridViewTextBoxColumn";
            this.groupThreeDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupThreeDataGridViewTextBoxColumn.Width = 120;
            // 
            // groupFourDataGridViewTextBoxColumn
            // 
            this.groupFourDataGridViewTextBoxColumn.DataPropertyName = "GroupFour";
            this.groupFourDataGridViewTextBoxColumn.HeaderText = "GroupFour";
            this.groupFourDataGridViewTextBoxColumn.Name = "groupFourDataGridViewTextBoxColumn";
            this.groupFourDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dTMatchesDataItemBindingSource
            // 
            this.dTMatchesDataItemBindingSource.DataSource = typeof(Draco_RegexTest.DTMatchesDataItem);
            // 
            // tableLayoutPanelSource
            // 
            this.tableLayoutPanelSource.ColumnCount = 1;
            this.tableLayoutPanelSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSource.Controls.Add(this.urlTextBox, 0, 0);
            this.tableLayoutPanelSource.Controls.Add(this.sourceTextBox, 0, 1);
            this.tableLayoutPanelSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSource.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSource.Name = "tableLayoutPanelSource";
            this.tableLayoutPanelSource.RowCount = 3;
            this.tableLayoutPanelSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanelSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanelSource.Size = new System.Drawing.Size(452, 646);
            this.tableLayoutPanelSource.TabIndex = 0;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.urlTextBox.Location = new System.Drawing.Point(3, 19);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(446, 20);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
            this.urlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.urlTextBox_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escapeToolStripMenuItem,
            this.escapeescapeitToolStripMenuItem,
            this.grabSourceSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // escapeToolStripMenuItem
            // 
            this.escapeToolStripMenuItem.Name = "escapeToolStripMenuItem";
            this.escapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.escapeToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.escapeToolStripMenuItem.Text = "un-escape-it";
            this.escapeToolStripMenuItem.Click += new System.EventHandler(this.escapeToolStripMenuItem_Click);
            // 
            // escapeescapeitToolStripMenuItem
            // 
            this.escapeescapeitToolStripMenuItem.Name = "escapeescapeitToolStripMenuItem";
            this.escapeescapeitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.escapeescapeitToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.escapeescapeitToolStripMenuItem.Text = "escape-escape-it";
            this.escapeescapeitToolStripMenuItem.Click += new System.EventHandler(this.escapeescapeitToolStripMenuItem_Click);
            // 
            // grabSourceSelectionToolStripMenuItem
            // 
            this.grabSourceSelectionToolStripMenuItem.Name = "grabSourceSelectionToolStripMenuItem";
            this.grabSourceSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.grabSourceSelectionToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.grabSourceSelectionToolStripMenuItem.Text = "Grab source selection";
            this.grabSourceSelectionToolStripMenuItem.Click += new System.EventHandler(this.grabSourceSelectionToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.responseToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1035, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // responseToolStripStatusLabel
            // 
            this.responseToolStripStatusLabel.Name = "responseToolStripStatusLabel";
            this.responseToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.responseToolStripStatusLabel.Text = "Ready";
            // 
            // startupBackgroundWorker
            // 
            this.startupBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.startupBackgroundWorker_DoWork);
            this.startupBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.startupBackgroundWorker_RunWorkerCompleted);
            // 
            // regexMatchBackgroundWorker
            // 
            this.regexMatchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.regexMatchBackgroundWorker_DoWork);
            this.regexMatchBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.regexMatchBackgroundWorker_RunWorkerCompleted);
            // 
            // urlFetchBackgroundWorker
            // 
            this.urlFetchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.urlFetchBackgroundWorker_DoWork);
            this.urlFetchBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.urlFetchBackgroundWorker_RunWorkerCompleted);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceTextBox.Location = new System.Drawing.Point(3, 45);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(446, 526);
            this.sourceTextBox.TabIndex = 1;
            this.sourceTextBox.Text = "";
            // 
            // Draco_RegexTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 696);
            this.Controls.Add(this.splitContainerMainLR);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Draco_RegexTestForm";
            this.Text = "Draco RegexTest";
            this.splitContainerMainLR.Panel1.ResumeLayout(false);
            this.splitContainerMainLR.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLR)).EndInit();
            this.splitContainerMainLR.ResumeLayout(false);
            this.splitContainerLeftSide.Panel1.ResumeLayout(false);
            this.splitContainerLeftSide.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftSide)).EndInit();
            this.splitContainerLeftSide.ResumeLayout(false);
            this.splitContainerEditor.Panel1.ResumeLayout(false);
            this.splitContainerEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditor)).EndInit();
            this.splitContainerEditor.ResumeLayout(false);
            this.tableLayoutPanelRegexEdit.ResumeLayout(false);
            this.tableLayoutPanelRegexEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regexDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTRegexItemBindingSource)).EndInit();
            this.splitContainerRegexResults.Panel1.ResumeLayout(false);
            this.splitContainerRegexResults.Panel1.PerformLayout();
            this.splitContainerRegexResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRegexResults)).EndInit();
            this.splitContainerRegexResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTMatchesDataItemBindingSource)).EndInit();
            this.tableLayoutPanelSource.ResumeLayout(false);
            this.tableLayoutPanelSource.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMainLR;
        private System.Windows.Forms.SplitContainer splitContainerLeftSide;
        private System.Windows.Forms.SplitContainer splitContainerEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRegexEdit;
        private System.Windows.Forms.CheckBox regexEditCheckBox;
        private System.Windows.Forms.TextBox regexEditTextBox;
        private System.Windows.Forms.Button AddRegexToListButton;
        private System.Windows.Forms.SplitContainer splitContainerRegexResults;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.TextBox totalMatchesTextBox;
        private System.Windows.Forms.Label totalMatchLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSource;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.DataGridView matchesDataGridView;
        private System.Windows.Forms.BindingSource dTMatchesDataItemBindingSource;
        private System.Windows.Forms.DataGridView regexDataGridView;
        private System.Windows.Forms.BindingSource dTRegexItemBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn matchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullMatchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupOneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupTwoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupThreeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupFourDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox matchShowLimitTextBox;
        private System.ComponentModel.BackgroundWorker startupBackgroundWorker;
        private System.ComponentModel.BackgroundWorker regexMatchBackgroundWorker;
        private System.Windows.Forms.ToolStripStatusLabel responseToolStripStatusLabel;
        private System.ComponentModel.BackgroundWorker urlFetchBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escapeescapeitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purposeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regexStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem grabSourceSelectionToolStripMenuItem;
        private System.Windows.Forms.RichTextBox sourceTextBox;
    }
}

