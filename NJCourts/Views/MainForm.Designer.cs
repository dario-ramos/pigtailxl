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
            this.rtbMessageLog = new System.Windows.Forms.RichTextBox();
            this.rtbZipCodeFilters = new System.Windows.Forms.RichTextBox();
            this.cbZipCodeFilters = new System.Windows.Forms.CheckBox();
            this.cbDateFilter = new System.Windows.Forms.CheckBox();
            this.txtDateFiledFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateFiledTo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCounties = new System.Windows.Forms.DataGridView();
            this.CountyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Processed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartProcess = new System.Windows.Forms.Button();
            this.btnStopProcess = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMessageLog
            // 
            this.rtbMessageLog.Location = new System.Drawing.Point(12, 522);
            this.rtbMessageLog.Name = "rtbMessageLog";
            this.rtbMessageLog.ReadOnly = true;
            this.rtbMessageLog.Size = new System.Drawing.Size(601, 109);
            this.rtbMessageLog.TabIndex = 0;
            this.rtbMessageLog.Text = "";
            // 
            // rtbZipCodeFilters
            // 
            this.rtbZipCodeFilters.Location = new System.Drawing.Point(17, 52);
            this.rtbZipCodeFilters.Name = "rtbZipCodeFilters";
            this.rtbZipCodeFilters.Size = new System.Drawing.Size(556, 44);
            this.rtbZipCodeFilters.TabIndex = 1;
            this.rtbZipCodeFilters.Text = "";
            // 
            // cbZipCodeFilters
            // 
            this.cbZipCodeFilters.AutoSize = true;
            this.cbZipCodeFilters.Location = new System.Drawing.Point(17, 20);
            this.cbZipCodeFilters.Name = "cbZipCodeFilters";
            this.cbZipCodeFilters.Size = new System.Drawing.Size(66, 17);
            this.cbZipCodeFilters.TabIndex = 2;
            this.cbZipCodeFilters.Text = "Zip Filter";
            this.cbZipCodeFilters.UseVisualStyleBackColor = true;
            // 
            // cbDateFilter
            // 
            this.cbDateFilter.AutoSize = true;
            this.cbDateFilter.Location = new System.Drawing.Point(17, 111);
            this.cbDateFilter.Name = "cbDateFilter";
            this.cbDateFilter.Size = new System.Drawing.Size(74, 17);
            this.cbDateFilter.TabIndex = 4;
            this.cbDateFilter.Text = "Date Filter";
            this.cbDateFilter.UseVisualStyleBackColor = true;
            // 
            // txtDateFiledFrom
            // 
            this.txtDateFiledFrom.Location = new System.Drawing.Point(17, 156);
            this.txtDateFiledFrom.Name = "txtDateFiledFrom";
            this.txtDateFiledFrom.Size = new System.Drawing.Size(117, 20);
            this.txtDateFiledFrom.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date Filed From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date Filed To";
            // 
            // txtDateFiledTo
            // 
            this.txtDateFiledTo.Location = new System.Drawing.Point(160, 156);
            this.txtDateFiledTo.Name = "txtDateFiledTo";
            this.txtDateFiledTo.Size = new System.Drawing.Size(117, 20);
            this.txtDateFiledTo.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbZipCodeFilters);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbZipCodeFilters);
            this.groupBox1.Controls.Add(this.txtDateFiledTo);
            this.groupBox1.Controls.Add(this.txtDateFiledFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbDateFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 190);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCounties);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 260);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // dgvCounties
            // 
            this.dgvCounties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCounties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountyName,
            this.CountyCode,
            this.Processed});
            this.dgvCounties.Location = new System.Drawing.Point(20, 20);
            this.dgvCounties.Name = "dgvCounties";
            this.dgvCounties.Size = new System.Drawing.Size(556, 225);
            this.dgvCounties.TabIndex = 0;
            // 
            // CountyName
            // 
            this.CountyName.HeaderText = "County Name";
            this.CountyName.Name = "CountyName";
            this.CountyName.ReadOnly = true;
            // 
            // CountyCode
            // 
            this.CountyCode.HeaderText = "County Code";
            this.CountyCode.Name = "CountyCode";
            this.CountyCode.ReadOnly = true;
            // 
            // Processed
            // 
            this.Processed.HeaderText = "Processed";
            this.Processed.Name = "Processed";
            this.Processed.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Message Log";
            // 
            // btnStartProcess
            // 
            this.btnStartProcess.Location = new System.Drawing.Point(413, 493);
            this.btnStartProcess.Name = "btnStartProcess";
            this.btnStartProcess.Size = new System.Drawing.Size(92, 23);
            this.btnStartProcess.TabIndex = 12;
            this.btnStartProcess.Text = "Start Process";
            this.btnStartProcess.UseVisualStyleBackColor = true;
            this.btnStartProcess.Click += new System.EventHandler(this.BtnStartProcess_OnClick);
            // 
            // btnStopProcess
            // 
            this.btnStopProcess.Location = new System.Drawing.Point(521, 493);
            this.btnStopProcess.Name = "btnStopProcess";
            this.btnStopProcess.Size = new System.Drawing.Size(92, 23);
            this.btnStopProcess.TabIndex = 13;
            this.btnStopProcess.Text = "Stop Process";
            this.btnStopProcess.UseVisualStyleBackColor = true;
            this.btnStopProcess.Click += new System.EventHandler(this.BtnStopProcess_OnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 643);
            this.Controls.Add(this.btnStopProcess);
            this.Controls.Add(this.btnStartProcess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbMessageLog);
            this.Name = "MainForm";
            this.Text = "NJCourts - Desktop App";
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMessageLog;
        private System.Windows.Forms.RichTextBox rtbZipCodeFilters;
        private System.Windows.Forms.CheckBox cbZipCodeFilters;
        private System.Windows.Forms.CheckBox cbDateFilter;
        private System.Windows.Forms.TextBox txtDateFiledFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateFiledTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCounties;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processed;
        private System.Windows.Forms.Button btnStartProcess;
        private System.Windows.Forms.Button btnStopProcess;
    }
}

