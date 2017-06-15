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
            this.SuspendLayout();
            // 
            // rtbMessageLog
            // 
            this.rtbMessageLog.Location = new System.Drawing.Point(29, 470);
            this.rtbMessageLog.Name = "rtbMessageLog";
            this.rtbMessageLog.ReadOnly = true;
            this.rtbMessageLog.Size = new System.Drawing.Size(559, 117);
            this.rtbMessageLog.TabIndex = 0;
            this.rtbMessageLog.Text = "";
            // 
            // rtbZipCodeFilters
            // 
            this.rtbZipCodeFilters.Location = new System.Drawing.Point(29, 283);
            this.rtbZipCodeFilters.Name = "rtbZipCodeFilters";
            this.rtbZipCodeFilters.Size = new System.Drawing.Size(559, 66);
            this.rtbZipCodeFilters.TabIndex = 1;
            this.rtbZipCodeFilters.Text = "";
            // 
            // cbZipCodeFilters
            // 
            this.cbZipCodeFilters.AutoSize = true;
            this.cbZipCodeFilters.Location = new System.Drawing.Point(29, 251);
            this.cbZipCodeFilters.Name = "cbZipCodeFilters";
            this.cbZipCodeFilters.Size = new System.Drawing.Size(66, 17);
            this.cbZipCodeFilters.TabIndex = 2;
            this.cbZipCodeFilters.Text = "Zip Filter";
            this.cbZipCodeFilters.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 609);
            this.Controls.Add(this.cbZipCodeFilters);
            this.Controls.Add(this.rtbZipCodeFilters);
            this.Controls.Add(this.rtbMessageLog);
            this.Name = "MainForm";
            this.Text = "NJCourts - Desktop App";
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMessageLog;
        private System.Windows.Forms.RichTextBox rtbZipCodeFilters;
        private System.Windows.Forms.CheckBox cbZipCodeFilters;
    }
}

