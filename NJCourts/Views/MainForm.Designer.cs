﻿using ComponentFactory.Krypton.Toolkit;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rtbMessageLog = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.dgvCounties = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.countiesCheckBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.CountyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Processed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.btnStartStopProcess = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnOpenCourtsDB = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtDocketYear = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMessageLog
            // 
            this.rtbMessageLog.Location = new System.Drawing.Point(21, 712);
            this.rtbMessageLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbMessageLog.Name = "rtbMessageLog";
            this.rtbMessageLog.ReadOnly = true;
            this.rtbMessageLog.Size = new System.Drawing.Size(791, 94);
            this.rtbMessageLog.TabIndex = 0;
            this.rtbMessageLog.Text = "";
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
            this.dgvCounties.Location = new System.Drawing.Point(21, 15);
            this.dgvCounties.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCounties.Name = "dgvCounties";
            this.dgvCounties.Size = new System.Drawing.Size(785, 594);
            this.dgvCounties.TabIndex = 0;
            this.dgvCounties.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCounties_OnCellMouseUp);
            this.dgvCounties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCounties_OnCellValueChanged);
            // 
            // countiesCheckBoxColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.countiesCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
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
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.SparkleBlue;
            // 
            // btnStartStopProcess
            // 
            this.btnStartStopProcess.Location = new System.Drawing.Point(21, 630);
            this.btnStartStopProcess.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStopProcess.Name = "btnStartStopProcess";
            this.btnStartStopProcess.Size = new System.Drawing.Size(145, 43);
            this.btnStartStopProcess.TabIndex = 14;
            this.btnStartStopProcess.Values.Text = "Start Process";
            this.btnStartStopProcess.Click += new System.EventHandler(this.BtnStartStopProcess_OnClick);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(16, 680);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(101, 24);
            this.kryptonLabel1.TabIndex = 18;
            this.kryptonLabel1.Values.Text = "Message Log";
            // 
            // btnOpenCourtsDB
            // 
            this.btnOpenCourtsDB.Location = new System.Drawing.Point(313, 632);
            this.btnOpenCourtsDB.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCourtsDB.Name = "btnOpenCourtsDB";
            this.btnOpenCourtsDB.Size = new System.Drawing.Size(160, 41);
            this.btnOpenCourtsDB.TabIndex = 19;
            this.btnOpenCourtsDB.Values.Text = "Open Database";
            this.btnOpenCourtsDB.Click += new System.EventHandler(this.BtnOpenCourtsDB_OnClick);
            // 
            // txtDocketYear
            // 
            this.txtDocketYear.Location = new System.Drawing.Point(655, 636);
            this.txtDocketYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtDocketYear.Name = "txtDocketYear";
            this.txtDocketYear.Size = new System.Drawing.Size(152, 27);
            this.txtDocketYear.TabIndex = 20;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(545, 636);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(94, 24);
            this.kryptonLabel2.TabIndex = 21;
            this.kryptonLabel2.Values.Text = "Docket Year";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 835);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtDocketYear);
            this.Controls.Add(this.btnOpenCourtsDB);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.dgvCounties);
            this.Controls.Add(this.btnStartStopProcess);
            this.Controls.Add(this.rtbMessageLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(851, 882);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "NJCourts - Desktop App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.Shown += new System.EventHandler(this.MainForm_OnShown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonRichTextBox rtbMessageLog;
        private KryptonDataGridView dgvCounties;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private KryptonButton btnStartStopProcess;
        private KryptonDataGridViewCheckBoxColumn countiesCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processed;
        private KryptonLabel kryptonLabel1;
        private KryptonButton btnOpenCourtsDB;
        private KryptonTextBox txtDocketYear;
        private KryptonLabel kryptonLabel2;
    }
}

