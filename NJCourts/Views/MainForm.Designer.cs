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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMessageLog
            // 
            this.rtbMessageLog.Location = new System.Drawing.Point(12, 488);
            this.rtbMessageLog.Name = "rtbMessageLog";
            this.rtbMessageLog.ReadOnly = true;
            this.rtbMessageLog.Size = new System.Drawing.Size(601, 109);
            this.rtbMessageLog.TabIndex = 0;
            this.rtbMessageLog.Text = "";
            // 
            // rtbZipCodeFilters
            // 
            this.rtbZipCodeFilters.Location = new System.Drawing.Point(20, 57);
            this.rtbZipCodeFilters.Name = "rtbZipCodeFilters";
            this.rtbZipCodeFilters.Size = new System.Drawing.Size(556, 66);
            this.rtbZipCodeFilters.TabIndex = 1;
            this.rtbZipCodeFilters.Text = "";
            // 
            // cbZipCodeFilters
            // 
            this.cbZipCodeFilters.AutoSize = true;
            this.cbZipCodeFilters.Location = new System.Drawing.Point(20, 34);
            this.cbZipCodeFilters.Name = "cbZipCodeFilters";
            this.cbZipCodeFilters.Size = new System.Drawing.Size(66, 17);
            this.cbZipCodeFilters.TabIndex = 2;
            this.cbZipCodeFilters.Text = "Zip Filter";
            this.cbZipCodeFilters.UseVisualStyleBackColor = true;
            // 
            // cbDateFilter
            // 
            this.cbDateFilter.AutoSize = true;
            this.cbDateFilter.Location = new System.Drawing.Point(20, 138);
            this.cbDateFilter.Name = "cbDateFilter";
            this.cbDateFilter.Size = new System.Drawing.Size(74, 17);
            this.cbDateFilter.TabIndex = 4;
            this.cbDateFilter.Text = "Date Filter";
            this.cbDateFilter.UseVisualStyleBackColor = true;
            // 
            // txtDateFiledFrom
            // 
            this.txtDateFiledFrom.Location = new System.Drawing.Point(20, 183);
            this.txtDateFiledFrom.Name = "txtDateFiledFrom";
            this.txtDateFiledFrom.Size = new System.Drawing.Size(117, 20);
            this.txtDateFiledFrom.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date Filed From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date Filed To";
            // 
            // txtDateFiledTo
            // 
            this.txtDateFiledTo.Location = new System.Drawing.Point(163, 183);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 216);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 220);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Message Log";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 609);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbMessageLog);
            this.Name = "MainForm";
            this.Text = "NJCourts - Desktop App";
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

