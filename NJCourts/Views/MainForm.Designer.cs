using ComponentFactory.Krypton.Toolkit;

namespace NJCourts
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rtbMessageLog = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.btnApplyFilters = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCounties = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.countiesCheckBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.CountyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Processed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.btnStartStopProcess = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFromFiles = new System.Windows.Forms.TabPage();
            this.tabFromDatabase = new System.Windows.Forms.TabPage();
            this.btnFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtZipFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDocketValueFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gbCaseFiledDate = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.dtpCaseFiledDate2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpCaseFiledDate1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.cmbCaseFiledDateComparison = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.gbDemandAmountFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txtDemandAmountValue2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDemandAmountValue1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cmbDemandAmountComparison = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtStateFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCityFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCaseStatusFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cmbVenueFilter = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.dgvCourts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabFromFiles.SuspendLayout();
            this.tabFromDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbCaseFiledDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCaseFiledDate.Panel)).BeginInit();
            this.gbCaseFiledDate.Panel.SuspendLayout();
            this.gbCaseFiledDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCaseFiledDateComparison)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDemandAmountFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDemandAmountFilter.Panel)).BeginInit();
            this.gbDemandAmountFilter.Panel.SuspendLayout();
            this.gbDemandAmountFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDemandAmountComparison)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVenueFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourts)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMessageLog
            // 
            this.rtbMessageLog.Location = new System.Drawing.Point(12, 647);
            this.rtbMessageLog.Name = "rtbMessageLog";
            this.rtbMessageLog.ReadOnly = true;
            this.rtbMessageLog.Size = new System.Drawing.Size(1683, 92);
            this.rtbMessageLog.TabIndex = 0;
            this.rtbMessageLog.Text = "";
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Location = new System.Drawing.Point(256, 561);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(90, 25);
            this.btnApplyFilters.TabIndex = 9;
            this.btnApplyFilters.Values.Text = "Apply";
            this.btnApplyFilters.Click += new System.EventHandler(this.BtnApplyFilters_OnClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCounties);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 549);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // dgvCounties
            // 
            this.dgvCounties.AllowUserToAddRows = false;
            this.dgvCounties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCounties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.countiesCheckBoxColumn,
            this.CountyName,
            this.CountyCode,
            this.Processed});
            this.dgvCounties.Location = new System.Drawing.Point(6, 19);
            this.dgvCounties.Name = "dgvCounties";
            this.dgvCounties.Size = new System.Drawing.Size(589, 524);
            this.dgvCounties.TabIndex = 0;
            this.dgvCounties.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCounties_OnCellMouseUp);
            this.dgvCounties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCounties_OnCellValueChanged);
            // 
            // countiesCheckBoxColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = false;
            this.countiesCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.countiesCheckBoxColumn.FalseValue = null;
            this.countiesCheckBoxColumn.FillWeight = 111.6751F;
            this.countiesCheckBoxColumn.HeaderText = "";
            this.countiesCheckBoxColumn.IndeterminateValue = null;
            this.countiesCheckBoxColumn.Name = "countiesCheckBoxColumn";
            this.countiesCheckBoxColumn.TrueValue = null;
            this.countiesCheckBoxColumn.Width = 55;
            // 
            // CountyName
            // 
            this.CountyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CountyName.FillWeight = 96.10829F;
            this.CountyName.HeaderText = "County Name";
            this.CountyName.Name = "CountyName";
            this.CountyName.ReadOnly = true;
            // 
            // CountyCode
            // 
            this.CountyCode.FillWeight = 96.10829F;
            this.CountyCode.HeaderText = "County Code";
            this.CountyCode.Name = "CountyCode";
            this.CountyCode.ReadOnly = true;
            this.CountyCode.Width = 123;
            // 
            // Processed
            // 
            this.Processed.FillWeight = 96.10829F;
            this.Processed.HeaderText = "Processed";
            this.Processed.Name = "Processed";
            this.Processed.ReadOnly = true;
            this.Processed.Width = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Message Log";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.SparkleBlue;
            // 
            // btnStartStopProcess
            // 
            this.btnStartStopProcess.Location = new System.Drawing.Point(1701, 667);
            this.btnStartStopProcess.Name = "btnStartStopProcess";
            this.btnStartStopProcess.Size = new System.Drawing.Size(90, 35);
            this.btnStartStopProcess.TabIndex = 14;
            this.btnStartStopProcess.Values.Text = "Start Process";
            this.btnStartStopProcess.Click += new System.EventHandler(this.BtnStartStopProcess_OnClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFromFiles);
            this.tabControl1.Controls.Add(this.tabFromDatabase);
            this.tabControl1.Location = new System.Drawing.Point(12, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1783, 618);
            this.tabControl1.TabIndex = 15;
            // 
            // tabFromFiles
            // 
            this.tabFromFiles.Controls.Add(this.btnApplyFilters);
            this.tabFromFiles.Controls.Add(this.groupBox2);
            this.tabFromFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFromFiles.Name = "tabFromFiles";
            this.tabFromFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFromFiles.Size = new System.Drawing.Size(1775, 592);
            this.tabFromFiles.TabIndex = 0;
            this.tabFromFiles.Text = "From Files";
            this.tabFromFiles.UseVisualStyleBackColor = true;
            // 
            // tabFromDatabase
            // 
            this.tabFromDatabase.Controls.Add(this.btnExport);
            this.tabFromDatabase.Controls.Add(this.btnFilter);
            this.tabFromDatabase.Controls.Add(this.kryptonLabel6);
            this.tabFromDatabase.Controls.Add(this.txtZipFilter);
            this.tabFromDatabase.Controls.Add(this.kryptonLabel5);
            this.tabFromDatabase.Controls.Add(this.txtDocketValueFilter);
            this.tabFromDatabase.Controls.Add(this.gbCaseFiledDate);
            this.tabFromDatabase.Controls.Add(this.gbDemandAmountFilter);
            this.tabFromDatabase.Controls.Add(this.kryptonLabel4);
            this.tabFromDatabase.Controls.Add(this.kryptonLabel3);
            this.tabFromDatabase.Controls.Add(this.kryptonLabel2);
            this.tabFromDatabase.Controls.Add(this.kryptonLabel1);
            this.tabFromDatabase.Controls.Add(this.txtStateFilter);
            this.tabFromDatabase.Controls.Add(this.txtCityFilter);
            this.tabFromDatabase.Controls.Add(this.txtCaseStatusFilter);
            this.tabFromDatabase.Controls.Add(this.cmbVenueFilter);
            this.tabFromDatabase.Controls.Add(this.dgvCourts);
            this.tabFromDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabFromDatabase.Name = "tabFromDatabase";
            this.tabFromDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabFromDatabase.Size = new System.Drawing.Size(1775, 592);
            this.tabFromDatabase.TabIndex = 1;
            this.tabFromDatabase.Text = "From Database";
            this.tabFromDatabase.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(1240, 512);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(116, 25);
            this.btnFilter.TabIndex = 16;
            this.btnFilter.Values.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_OnClick);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(1095, 486);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(41, 20);
            this.kryptonLabel6.TabIndex = 15;
            this.kryptonLabel6.Values.Text = "Zip(s)";
            // 
            // txtZipFilter
            // 
            this.txtZipFilter.Location = new System.Drawing.Point(1095, 512);
            this.txtZipFilter.Name = "txtZipFilter";
            this.txtZipFilter.Size = new System.Drawing.Size(119, 23);
            this.txtZipFilter.TabIndex = 14;
            this.txtZipFilter.TextChanged += new System.EventHandler(this.TxtZipFilter_OnTextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(671, 486);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel5.TabIndex = 13;
            this.kryptonLabel5.Values.Text = "Docket Value";
            // 
            // txtDocketValueFilter
            // 
            this.txtDocketValueFilter.Location = new System.Drawing.Point(671, 512);
            this.txtDocketValueFilter.Name = "txtDocketValueFilter";
            this.txtDocketValueFilter.Size = new System.Drawing.Size(115, 23);
            this.txtDocketValueFilter.TabIndex = 12;
            this.txtDocketValueFilter.TextChanged += new System.EventHandler(this.TxtDocketValueFilter_OnTextChanged);
            // 
            // gbCaseFiledDate
            // 
            this.gbCaseFiledDate.CaptionOverlap = 1D;
            this.gbCaseFiledDate.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.gbCaseFiledDate.Location = new System.Drawing.Point(276, 488);
            this.gbCaseFiledDate.Name = "gbCaseFiledDate";
            // 
            // gbCaseFiledDate.Panel
            // 
            this.gbCaseFiledDate.Panel.Controls.Add(this.dtpCaseFiledDate2);
            this.gbCaseFiledDate.Panel.Controls.Add(this.dtpCaseFiledDate1);
            this.gbCaseFiledDate.Panel.Controls.Add(this.cmbCaseFiledDateComparison);
            this.gbCaseFiledDate.Size = new System.Drawing.Size(178, 88);
            this.gbCaseFiledDate.TabIndex = 11;
            this.gbCaseFiledDate.Values.Heading = "Case Filed Date";
            // 
            // dtpCaseFiledDate2
            // 
            this.dtpCaseFiledDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaseFiledDate2.Location = new System.Drawing.Point(78, 33);
            this.dtpCaseFiledDate2.Name = "dtpCaseFiledDate2";
            this.dtpCaseFiledDate2.Size = new System.Drawing.Size(93, 21);
            this.dtpCaseFiledDate2.TabIndex = 2;
            this.dtpCaseFiledDate2.ValueChanged += new System.EventHandler(this.DtpCaseFiledDate2_OnValueChanged);
            // 
            // dtpCaseFiledDate1
            // 
            this.dtpCaseFiledDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaseFiledDate1.Location = new System.Drawing.Point(78, 6);
            this.dtpCaseFiledDate1.Name = "dtpCaseFiledDate1";
            this.dtpCaseFiledDate1.Size = new System.Drawing.Size(93, 21);
            this.dtpCaseFiledDate1.TabIndex = 1;
            this.dtpCaseFiledDate1.ValueChanged += new System.EventHandler(this.DtpCaseFiledDate1_OnValueChanged);
            // 
            // cmbCaseFiledDateComparison
            // 
            this.cmbCaseFiledDateComparison.DropDownWidth = 69;
            this.cmbCaseFiledDateComparison.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "RANGE"});
            this.cmbCaseFiledDateComparison.Location = new System.Drawing.Point(3, 21);
            this.cmbCaseFiledDateComparison.Name = "cmbCaseFiledDateComparison";
            this.cmbCaseFiledDateComparison.Size = new System.Drawing.Size(69, 21);
            this.cmbCaseFiledDateComparison.TabIndex = 0;
            this.cmbCaseFiledDateComparison.SelectedIndexChanged += new System.EventHandler(this.CmbCaseFiledDateComparison_OnSelectedIndexChanged);
            // 
            // gbDemandAmountFilter
            // 
            this.gbDemandAmountFilter.CaptionOverlap = 1D;
            this.gbDemandAmountFilter.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.gbDemandAmountFilter.Location = new System.Drawing.Point(470, 488);
            this.gbDemandAmountFilter.Name = "gbDemandAmountFilter";
            // 
            // gbDemandAmountFilter.Panel
            // 
            this.gbDemandAmountFilter.Panel.Controls.Add(this.txtDemandAmountValue2);
            this.gbDemandAmountFilter.Panel.Controls.Add(this.txtDemandAmountValue1);
            this.gbDemandAmountFilter.Panel.Controls.Add(this.cmbDemandAmountComparison);
            this.gbDemandAmountFilter.Size = new System.Drawing.Size(178, 88);
            this.gbDemandAmountFilter.TabIndex = 10;
            this.gbDemandAmountFilter.Values.Heading = "Demand Amount";
            // 
            // txtDemandAmountValue2
            // 
            this.txtDemandAmountValue2.Enabled = false;
            this.txtDemandAmountValue2.Location = new System.Drawing.Point(78, 35);
            this.txtDemandAmountValue2.Name = "txtDemandAmountValue2";
            this.txtDemandAmountValue2.Size = new System.Drawing.Size(93, 23);
            this.txtDemandAmountValue2.TabIndex = 2;
            this.txtDemandAmountValue2.TextChanged += new System.EventHandler(this.TxtDemandAmountValue2_OnTextChanged);
            // 
            // txtDemandAmountValue1
            // 
            this.txtDemandAmountValue1.Location = new System.Drawing.Point(78, 6);
            this.txtDemandAmountValue1.Name = "txtDemandAmountValue1";
            this.txtDemandAmountValue1.Size = new System.Drawing.Size(93, 23);
            this.txtDemandAmountValue1.TabIndex = 1;
            this.txtDemandAmountValue1.TextChanged += new System.EventHandler(this.TxtDemandAmountValue1_OnTextChanged);
            // 
            // cmbDemandAmountComparison
            // 
            this.cmbDemandAmountComparison.DropDownWidth = 69;
            this.cmbDemandAmountComparison.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "RANGE"});
            this.cmbDemandAmountComparison.Location = new System.Drawing.Point(3, 21);
            this.cmbDemandAmountComparison.Name = "cmbDemandAmountComparison";
            this.cmbDemandAmountComparison.Size = new System.Drawing.Size(69, 21);
            this.cmbDemandAmountComparison.TabIndex = 0;
            this.cmbDemandAmountComparison.SelectedIndexChanged += new System.EventHandler(this.CmbDemandAmountComparison_OnSelectedIndexChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(950, 486);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel4.TabIndex = 9;
            this.kryptonLabel4.Values.Text = "State";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(810, 486);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(31, 20);
            this.kryptonLabel3.TabIndex = 8;
            this.kryptonLabel3.Values.Text = "City";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(157, 488);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Case Status";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 486);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Venue";
            // 
            // txtStateFilter
            // 
            this.txtStateFilter.Location = new System.Drawing.Point(950, 512);
            this.txtStateFilter.Name = "txtStateFilter";
            this.txtStateFilter.Size = new System.Drawing.Size(119, 23);
            this.txtStateFilter.TabIndex = 5;
            this.txtStateFilter.TextChanged += new System.EventHandler(this.TxtStateFilter_OnTextChanged);
            // 
            // txtCityFilter
            // 
            this.txtCityFilter.Location = new System.Drawing.Point(810, 512);
            this.txtCityFilter.Name = "txtCityFilter";
            this.txtCityFilter.Size = new System.Drawing.Size(115, 23);
            this.txtCityFilter.TabIndex = 4;
            this.txtCityFilter.TextChanged += new System.EventHandler(this.TxtCityFilter_OnTextChanged);
            // 
            // txtCaseStatusFilter
            // 
            this.txtCaseStatusFilter.Location = new System.Drawing.Point(157, 514);
            this.txtCaseStatusFilter.Name = "txtCaseStatusFilter";
            this.txtCaseStatusFilter.Size = new System.Drawing.Size(101, 23);
            this.txtCaseStatusFilter.TabIndex = 3;
            this.txtCaseStatusFilter.TextChanged += new System.EventHandler(this.TxtCaseStatusFilter_OnTextChanged);
            // 
            // cmbVenueFilter
            // 
            this.cmbVenueFilter.DropDownWidth = 121;
            this.cmbVenueFilter.Location = new System.Drawing.Point(6, 514);
            this.cmbVenueFilter.Name = "cmbVenueFilter";
            this.cmbVenueFilter.Size = new System.Drawing.Size(133, 21);
            this.cmbVenueFilter.TabIndex = 2;
            this.cmbVenueFilter.SelectedIndexChanged += new System.EventHandler(this.CmbVenueFilter_OnSelectedIndexChanged);
            // 
            // dgvCourts
            // 
            this.dgvCourts.AllowUserToAddRows = false;
            this.dgvCourts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourts.Location = new System.Drawing.Point(6, 27);
            this.dgvCourts.Name = "dgvCourts";
            this.dgvCourts.Size = new System.Drawing.Size(1763, 445);
            this.dgvCourts.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1371, 512);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(116, 25);
            this.btnExport.TabIndex = 17;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_OnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1807, 751);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnStartStopProcess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbMessageLog);
            this.Name = "MainForm";
            this.Text = "NJCourts - Desktop App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.Shown += new System.EventHandler(this.MainForm_OnShown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabFromFiles.ResumeLayout(false);
            this.tabFromDatabase.ResumeLayout(false);
            this.tabFromDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbCaseFiledDate.Panel)).EndInit();
            this.gbCaseFiledDate.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbCaseFiledDate)).EndInit();
            this.gbCaseFiledDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbCaseFiledDateComparison)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDemandAmountFilter.Panel)).EndInit();
            this.gbDemandAmountFilter.Panel.ResumeLayout(false);
            this.gbDemandAmountFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDemandAmountFilter)).EndInit();
            this.gbDemandAmountFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbDemandAmountComparison)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVenueFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonRichTextBox rtbMessageLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private KryptonDataGridView dgvCounties;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private KryptonButton btnStartStopProcess;
        private KryptonButton btnApplyFilters;
        private KryptonDataGridViewCheckBoxColumn countiesCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processed;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFromFiles;
        private System.Windows.Forms.TabPage tabFromDatabase;
        private KryptonDataGridView dgvCourts;
        private KryptonComboBox cmbVenueFilter;
        private KryptonTextBox txtCaseStatusFilter;
        private KryptonTextBox txtCityFilter;
        private KryptonTextBox txtStateFilter;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonGroupBox gbDemandAmountFilter;
        private KryptonComboBox cmbDemandAmountComparison;
        private KryptonTextBox txtDemandAmountValue2;
        private KryptonTextBox txtDemandAmountValue1;
        private KryptonGroupBox gbCaseFiledDate;
        private KryptonComboBox cmbCaseFiledDateComparison;
        private KryptonDateTimePicker dtpCaseFiledDate2;
        private KryptonDateTimePicker dtpCaseFiledDate1;
        private KryptonLabel kryptonLabel5;
        private KryptonTextBox txtDocketValueFilter;
        private KryptonLabel kryptonLabel6;
        private KryptonTextBox txtZipFilter;
        private KryptonButton btnFilter;
        private KryptonButton btnExport;
    }
}

