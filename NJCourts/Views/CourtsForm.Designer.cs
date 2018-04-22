namespace NJCourts.Views
{
    partial class CourtsForm
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
            this.dgvCourts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
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
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCityFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCaseStatusFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cmbVenueFilter = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtStateFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtZipFilter = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbShowAllRecords = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnMarkRecordsAsOld = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDeleteZipList = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSaveZipList = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbPredefinedZipLists = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPredefinedZipLists)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCourts
            // 
            this.dgvCourts.AllowUserToAddRows = false;
            this.dgvCourts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCourts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCourts.Location = new System.Drawing.Point(0, 0);
            this.dgvCourts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCourts.Name = "dgvCourts";
            this.dgvCourts.Size = new System.Drawing.Size(1924, 620);
            this.dgvCourts.TabIndex = 2;
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DropDownWidth = 121;
            this.kryptonComboBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(121, 25);
            this.kryptonComboBox1.TabIndex = 0;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel5.Location = new System.Drawing.Point(1039, 170);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(102, 24);
            this.kryptonLabel5.TabIndex = 23;
            this.kryptonLabel5.Values.Text = "Docket Value";
            // 
            // txtDocketValueFilter
            // 
            this.txtDocketValueFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDocketValueFilter.Location = new System.Drawing.Point(1039, 194);
            this.txtDocketValueFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtDocketValueFilter.Name = "txtDocketValueFilter";
            this.txtDocketValueFilter.Size = new System.Drawing.Size(221, 27);
            this.txtDocketValueFilter.TabIndex = 22;
            this.txtDocketValueFilter.TextChanged += new System.EventHandler(this.TxtDocketValueFilter_OnTextChanged);
            // 
            // gbCaseFiledDate
            // 
            this.gbCaseFiledDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCaseFiledDate.CaptionOverlap = 1D;
            this.gbCaseFiledDate.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.gbCaseFiledDate.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonLowProfile;
            this.gbCaseFiledDate.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.GridHeaderColumnList;
            this.gbCaseFiledDate.Location = new System.Drawing.Point(5, 17);
            this.gbCaseFiledDate.Margin = new System.Windows.Forms.Padding(4);
            this.gbCaseFiledDate.Name = "gbCaseFiledDate";
            // 
            // gbCaseFiledDate.Panel
            // 
            this.gbCaseFiledDate.Panel.Controls.Add(this.dtpCaseFiledDate2);
            this.gbCaseFiledDate.Panel.Controls.Add(this.dtpCaseFiledDate1);
            this.gbCaseFiledDate.Panel.Controls.Add(this.cmbCaseFiledDateComparison);
            this.gbCaseFiledDate.Size = new System.Drawing.Size(136, 146);
            this.gbCaseFiledDate.TabIndex = 21;
            this.gbCaseFiledDate.Values.Heading = "Case Filed Date";
            // 
            // dtpCaseFiledDate2
            // 
            this.dtpCaseFiledDate2.Enabled = false;
            this.dtpCaseFiledDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaseFiledDate2.Location = new System.Drawing.Point(4, 76);
            this.dtpCaseFiledDate2.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCaseFiledDate2.Name = "dtpCaseFiledDate2";
            this.dtpCaseFiledDate2.Size = new System.Drawing.Size(124, 25);
            this.dtpCaseFiledDate2.TabIndex = 2;
            this.dtpCaseFiledDate2.ValueChanged += new System.EventHandler(this.DtpCaseFiledDate2_ValueChanged);
            // 
            // dtpCaseFiledDate1
            // 
            this.dtpCaseFiledDate1.Enabled = false;
            this.dtpCaseFiledDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaseFiledDate1.Location = new System.Drawing.Point(4, 43);
            this.dtpCaseFiledDate1.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCaseFiledDate1.Name = "dtpCaseFiledDate1";
            this.dtpCaseFiledDate1.Size = new System.Drawing.Size(124, 25);
            this.dtpCaseFiledDate1.TabIndex = 1;
            this.dtpCaseFiledDate1.ValueChanged += new System.EventHandler(this.DtpCaseFiledDate1_ValueChanged);
            // 
            // cmbCaseFiledDateComparison
            // 
            this.cmbCaseFiledDateComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaseFiledDateComparison.DropDownWidth = 69;
            this.cmbCaseFiledDateComparison.Items.AddRange(new object[] {
            "NONE",
            "<=",
            ">=",
            "RANGE"});
            this.cmbCaseFiledDateComparison.Location = new System.Drawing.Point(4, 9);
            this.cmbCaseFiledDateComparison.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCaseFiledDateComparison.Name = "cmbCaseFiledDateComparison";
            this.cmbCaseFiledDateComparison.Size = new System.Drawing.Size(124, 25);
            this.cmbCaseFiledDateComparison.TabIndex = 0;
            this.cmbCaseFiledDateComparison.SelectedIndexChanged += new System.EventHandler(this.CmbCaseFiledDateComparison_OnSelectedIndexChanged);
            // 
            // gbDemandAmountFilter
            // 
            this.gbDemandAmountFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDemandAmountFilter.CaptionOverlap = 1D;
            this.gbDemandAmountFilter.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.gbDemandAmountFilter.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonLowProfile;
            this.gbDemandAmountFilter.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.GridHeaderColumnList;
            this.gbDemandAmountFilter.Location = new System.Drawing.Point(764, 171);
            this.gbDemandAmountFilter.Margin = new System.Windows.Forms.Padding(4);
            this.gbDemandAmountFilter.Name = "gbDemandAmountFilter";
            // 
            // gbDemandAmountFilter.Panel
            // 
            this.gbDemandAmountFilter.Panel.Controls.Add(this.txtDemandAmountValue2);
            this.gbDemandAmountFilter.Panel.Controls.Add(this.txtDemandAmountValue1);
            this.gbDemandAmountFilter.Panel.Controls.Add(this.cmbDemandAmountComparison);
            this.gbDemandAmountFilter.Size = new System.Drawing.Size(231, 135);
            this.gbDemandAmountFilter.TabIndex = 20;
            this.gbDemandAmountFilter.Values.Heading = "Demand Amount";
            // 
            // txtDemandAmountValue2
            // 
            this.txtDemandAmountValue2.Enabled = false;
            this.txtDemandAmountValue2.Location = new System.Drawing.Point(4, 73);
            this.txtDemandAmountValue2.Margin = new System.Windows.Forms.Padding(4);
            this.txtDemandAmountValue2.Name = "txtDemandAmountValue2";
            this.txtDemandAmountValue2.Size = new System.Drawing.Size(220, 27);
            this.txtDemandAmountValue2.TabIndex = 2;
            this.txtDemandAmountValue2.TextChanged += new System.EventHandler(this.TxtDemandAmountValue2_OnTextChanged);
            // 
            // txtDemandAmountValue1
            // 
            this.txtDemandAmountValue1.Enabled = false;
            this.txtDemandAmountValue1.Location = new System.Drawing.Point(4, 37);
            this.txtDemandAmountValue1.Margin = new System.Windows.Forms.Padding(4);
            this.txtDemandAmountValue1.Name = "txtDemandAmountValue1";
            this.txtDemandAmountValue1.Size = new System.Drawing.Size(220, 27);
            this.txtDemandAmountValue1.TabIndex = 1;
            this.txtDemandAmountValue1.TextChanged += new System.EventHandler(this.TxtDemandAmountValue1_OnTextChanged);
            // 
            // cmbDemandAmountComparison
            // 
            this.cmbDemandAmountComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDemandAmountComparison.DropDownWidth = 69;
            this.cmbDemandAmountComparison.Items.AddRange(new object[] {
            "NONE",
            "<=",
            ">=",
            "RANGE"});
            this.cmbDemandAmountComparison.Location = new System.Drawing.Point(4, 4);
            this.cmbDemandAmountComparison.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDemandAmountComparison.Name = "cmbDemandAmountComparison";
            this.cmbDemandAmountComparison.Size = new System.Drawing.Size(220, 25);
            this.cmbDemandAmountComparison.TabIndex = 0;
            this.cmbDemandAmountComparison.SelectedIndexChanged += new System.EventHandler(this.CmbDemandAmountComparison_OnSelectedIndexChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel3.Location = new System.Drawing.Point(1283, 168);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(38, 24);
            this.kryptonLabel3.TabIndex = 19;
            this.kryptonLabel3.Values.Text = "City";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel2.Location = new System.Drawing.Point(487, 172);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(90, 24);
            this.kryptonLabel2.TabIndex = 18;
            this.kryptonLabel2.Values.Text = "Case Status";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel1.Location = new System.Drawing.Point(199, 172);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(55, 24);
            this.kryptonLabel1.TabIndex = 17;
            this.kryptonLabel1.Values.Text = "Venue";
            // 
            // txtCityFilter
            // 
            this.txtCityFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCityFilter.Location = new System.Drawing.Point(1285, 193);
            this.txtCityFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtCityFilter.Name = "txtCityFilter";
            this.txtCityFilter.Size = new System.Drawing.Size(224, 27);
            this.txtCityFilter.TabIndex = 16;
            this.txtCityFilter.TextChanged += new System.EventHandler(this.TxtCityFilter_OnTextChanged);
            // 
            // txtCaseStatusFilter
            // 
            this.txtCaseStatusFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCaseStatusFilter.Location = new System.Drawing.Point(487, 197);
            this.txtCaseStatusFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaseStatusFilter.Name = "txtCaseStatusFilter";
            this.txtCaseStatusFilter.Size = new System.Drawing.Size(229, 27);
            this.txtCaseStatusFilter.TabIndex = 15;
            this.txtCaseStatusFilter.TextChanged += new System.EventHandler(this.TxtCaseStatusFilter_OnTextChanged);
            // 
            // cmbVenueFilter
            // 
            this.cmbVenueFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbVenueFilter.DropDownWidth = 121;
            this.cmbVenueFilter.Location = new System.Drawing.Point(204, 197);
            this.cmbVenueFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbVenueFilter.Name = "cmbVenueFilter";
            this.cmbVenueFilter.Size = new System.Drawing.Size(239, 25);
            this.cmbVenueFilter.TabIndex = 14;
            this.cmbVenueFilter.SelectedIndexChanged += new System.EventHandler(this.CmbVenueFilter_OnSelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(1584, 90);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(189, 31);
            this.btnExport.TabIndex = 29;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_OnClick);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(1584, 48);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(189, 31);
            this.btnFilter.TabIndex = 28;
            this.btnFilter.Values.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_OnClick);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel6.Location = new System.Drawing.Point(204, 17);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(49, 24);
            this.kryptonLabel6.TabIndex = 27;
            this.kryptonLabel6.Values.Text = "Zip(s)";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel4.Location = new System.Drawing.Point(1536, 169);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(46, 24);
            this.kryptonLabel4.TabIndex = 25;
            this.kryptonLabel4.Values.Text = "State";
            // 
            // txtStateFilter
            // 
            this.txtStateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStateFilter.Location = new System.Drawing.Point(1536, 193);
            this.txtStateFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtStateFilter.Name = "txtStateFilter";
            this.txtStateFilter.Size = new System.Drawing.Size(236, 27);
            this.txtStateFilter.TabIndex = 24;
            this.txtStateFilter.TextChanged += new System.EventHandler(this.TxtStateFilter_OnTextChanged);
            // 
            // txtZipFilter
            // 
            this.txtZipFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtZipFilter.Location = new System.Drawing.Point(196, 48);
            this.txtZipFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtZipFilter.Name = "txtZipFilter";
            this.txtZipFilter.Size = new System.Drawing.Size(1313, 118);
            this.txtZipFilter.TabIndex = 32;
            this.txtZipFilter.Text = "";
            this.txtZipFilter.TextChanged += new System.EventHandler(this.TxtZipFilter_OnTextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbShowAllRecords);
            this.panel1.Controls.Add(this.btnMarkRecordsAsOld);
            this.panel1.Controls.Add(this.btnDeleteZipList);
            this.panel1.Controls.Add(this.btnSaveZipList);
            this.panel1.Controls.Add(this.cmbPredefinedZipLists);
            this.panel1.Controls.Add(this.txtZipFilter);
            this.panel1.Controls.Add(this.cmbVenueFilter);
            this.panel1.Controls.Add(this.txtCaseStatusFilter);
            this.panel1.Controls.Add(this.txtCityFilter);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.kryptonLabel2);
            this.panel1.Controls.Add(this.kryptonLabel6);
            this.panel1.Controls.Add(this.kryptonLabel3);
            this.panel1.Controls.Add(this.kryptonLabel4);
            this.panel1.Controls.Add(this.gbDemandAmountFilter);
            this.panel1.Controls.Add(this.txtStateFilter);
            this.panel1.Controls.Add(this.gbCaseFiledDate);
            this.panel1.Controls.Add(this.kryptonLabel5);
            this.panel1.Controls.Add(this.txtDocketValueFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 620);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 321);
            this.panel1.TabIndex = 33;
            // 
            // cbShowAllRecords
            // 
            this.cbShowAllRecords.Location = new System.Drawing.Point(1618, 13);
            this.cbShowAllRecords.Name = "cbShowAllRecords";
            this.cbShowAllRecords.Size = new System.Drawing.Size(136, 24);
            this.cbShowAllRecords.TabIndex = 37;
            this.cbShowAllRecords.Values.Text = "Show all records";
            this.cbShowAllRecords.CheckedChanged += new System.EventHandler(this.CbShowAllRecords_OnCheckedChanged);
            // 
            // btnMarkRecordsAsOld
            // 
            this.btnMarkRecordsAsOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarkRecordsAsOld.Location = new System.Drawing.Point(1584, 135);
            this.btnMarkRecordsAsOld.Margin = new System.Windows.Forms.Padding(4);
            this.btnMarkRecordsAsOld.Name = "btnMarkRecordsAsOld";
            this.btnMarkRecordsAsOld.Size = new System.Drawing.Size(189, 31);
            this.btnMarkRecordsAsOld.TabIndex = 36;
            this.btnMarkRecordsAsOld.Values.Text = "Mark records as old";
            this.btnMarkRecordsAsOld.Click += new System.EventHandler(this.BtnMarkRecordsAsOld_OnClick);
            // 
            // btnDeleteZipList
            // 
            this.btnDeleteZipList.Location = new System.Drawing.Point(661, 15);
            this.btnDeleteZipList.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteZipList.Name = "btnDeleteZipList";
            this.btnDeleteZipList.Size = new System.Drawing.Size(145, 29);
            this.btnDeleteZipList.TabIndex = 35;
            this.btnDeleteZipList.Values.Text = "Delete List";
            this.btnDeleteZipList.Click += new System.EventHandler(this.BtnDeleteZipList_OnClick);
            // 
            // btnSaveZipList
            // 
            this.btnSaveZipList.Location = new System.Drawing.Point(508, 15);
            this.btnSaveZipList.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveZipList.Name = "btnSaveZipList";
            this.btnSaveZipList.Size = new System.Drawing.Size(145, 29);
            this.btnSaveZipList.TabIndex = 34;
            this.btnSaveZipList.Values.Text = "Save List";
            this.btnSaveZipList.Click += new System.EventHandler(this.BtnSaveZipList_OnClick);
            // 
            // cmbPredefinedZipLists
            // 
            this.cmbPredefinedZipLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbPredefinedZipLists.DropDownWidth = 121;
            this.cmbPredefinedZipLists.Location = new System.Drawing.Point(261, 17);
            this.cmbPredefinedZipLists.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPredefinedZipLists.Name = "cmbPredefinedZipLists";
            this.cmbPredefinedZipLists.Size = new System.Drawing.Size(239, 25);
            this.cmbPredefinedZipLists.TabIndex = 33;
            this.cmbPredefinedZipLists.SelectedIndexChanged += new System.EventHandler(this.CmbPredefinedZipLists_OnSelectedIndexChanged);
            // 
            // CourtsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 897);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvCourts);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CourtsForm";
            this.Text = "NJCourts - Database view";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CourtsForm_OnLoad);
            this.Shown += new System.EventHandler(this.CourtsForm_OnShown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPredefinedZipLists)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCourts;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDocketValueFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbCaseFiledDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpCaseFiledDate2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpCaseFiledDate1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbCaseFiledDateComparison;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbDemandAmountFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDemandAmountValue2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDemandAmountValue1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbDemandAmountComparison;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCityFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCaseStatusFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbVenueFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtStateFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtZipFilter;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbPredefinedZipLists;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDeleteZipList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveZipList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnMarkRecordsAsOld;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbShowAllRecords;
    }
}