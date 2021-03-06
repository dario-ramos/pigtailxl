﻿using NJCourts.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using NJCourts.Models;
using ComponentFactory.Krypton.Toolkit;
using System.Linq;
using System.Globalization;
using System.Data;

namespace NJCourts
{
    /**
     * Application main and only form
     */
    public partial class MainForm : KryptonForm, IMainView
    {
        private Presenters.MainPresenter _presenter;

        /**
         * Constructor: Initializes view 
         */
        public MainForm()
        {
            InitializeComponent();
            Enabled = false;
            ProcessRunning = true;
            StoppingProcess();
        }

        public bool FiltersEnabled
        {
            set
            {
                this.Enabled = value;
            }
        }

        public bool ProcessRunning
        {
            get
            {
                return btnStartStopProcess.Text == "Stop Process";
            }
            set
            {
                btnStartStopProcess.Text = value ? "Stop Process" : "Start Process";
                btnStartStopProcess.Enabled = true;
            }
        }

        public List<County> SelectedCounties
        {
            get
            {
                var selectedCounties = new List<County>();
                foreach(DataGridViewRow countyRow in dgvCounties.Rows)
                {
                    if ((bool)countyRow.Cells[0].Value)
                    {
                        selectedCounties.Add
                        (
                            new County
                            {
                                Code = (int) countyRow.Cells["CountyCode"].Value,
                                Name = (string) countyRow.Cells["CountyName"].Value,
                                Processed = ((string) countyRow.Cells["Processed"].Value == "Processed"),
                                Selected = true,
                            }
                        );
                    }
                }
                return selectedCounties;
            }
        }

        /**
         * Fill the grid with county data
         */
        public void SetCounties(List<County> counties)
        {
            dgvCounties.Rows.Clear();
            counties.Sort(delegate (County c1, County c2) { return c1.Name.CompareTo(c2.Name); });
            foreach(County county in counties)
            {
                dgvCounties.Rows.Add(county.Selected, county.Name, county.Code, county.Processed? "Processed" : "");
                if (county.Selected)
                {
                    dgvCounties.Rows[dgvCounties.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
            dgvCounties.Refresh();
        }

        public void SetDocketYear(int docketYear)
        {
            txtDocketYear.Text = docketYear.ToString();
        }

        /**
         * Display an error message. It's appended, so older ones are kept
         * Save current color, set to red, print and restore
         */
        public void ShowErrorMessage(string errorMsg)
        {
            ShowColoredTextMessage(errorMsg, Color.Red);
        }

        /**
         * Display a warning message. It's appended, so older ones are kept
         * Save current color, set to orange, print and restore
         */
        public void ShowWarningMessage(string msg)
        {
            ShowColoredTextMessage(msg, Color.Orange);
        }

        /**
         * Disable start/stop button while waiting for process to stop
         */
        public void StoppingProcess()
        {
            btnStartStopProcess.Enabled = false;
            btnStartStopProcess.Text = "Stopping...";
        }

        /**
         * Search the county in the grid and update it
         */
        public void UpdateCounty(County county)
        {
            foreach(DataGridViewRow row in dgvCounties.Rows)
            {
                if(row.Cells["CountyName"].Value == null)
                {
                    continue;
                }
                if (row.Cells["CountyName"].Value.ToString().Trim() == county.Name)
                {
                    row.Cells["CountyCode"].Value = county.Code.ToString();
                    row.Cells["Processed"].Value = county.Processed? "Processed" : "";
                    break;
                }
            }
        }

        private void AddCheckAllCheckbox()
        {
            KryptonDataGridViewCheckBoxColumn checkBoxColumn = (KryptonDataGridViewCheckBoxColumn)dgvCounties.Columns[0];
            checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Create checkbox control
            KryptonCheckBox checkboxHeader = new KryptonCheckBox();
            checkboxHeader.Checked = false;
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Text = "";
            checkboxHeader.Size = new Size(15, 15);
            //Position it and center it inside its cell
            Rectangle rect = dgvCounties.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + (rect.Width / 2) - checkboxHeader.Width / 2;
            rect.Y = rect.Location.Y + rect.Height / 2 - checkboxHeader.Height / 2;
            checkboxHeader.Location = rect.Location;
            //Handle checked changed event and add to grid
            checkboxHeader.CheckedChanged += new EventHandler(CheckBoxHeader_OnCheckedChanged);
            dgvCounties.Controls.Add(checkboxHeader);
        }

        private void BtnOpenCourtsDB_OnClick(object sender, EventArgs e)
        {
            var courtsForm = new CourtsForm(_presenter.FileDataHandler);
            courtsForm.Show();
        }

        private void BtnStartStopProcess_OnClick(object sender, EventArgs e)
        {
            try
            {
                int docketYear = 0;
                if (!int.TryParse(txtDocketYear.Text, out docketYear))
                {
                    MessageBox.Show("Cannot start process without a docket year");
                    return;
                }
                if (!ProcessRunning)
                {
                    _presenter.ApplyFiltersFromFiles();
                }
                _presenter.StartStopProcess(docketYear);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void CheckBoxHeader_OnCheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvCounties.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["countiesCheckBoxColumn"]).Value =  ((KryptonCheckBox)sender).Checked;
            }
            dgvCounties.RefreshEdit();
        }


        private void DgvCounties_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvCounties.EndEdit();
        }

        private void DgvCounties_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                bool isChecked = (bool)dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dgvCounties.Rows[e.RowIndex].DefaultCellStyle.BackColor = isChecked ? Color.LightBlue : dgvCounties.RowsDefaultCellStyle.BackColor;
            }
        }

        /**
         * Print an error message
         */
        private void HandleError(Exception ex)
        {
            ShowErrorMessage("ERROR: " + ex.Message);
        }

        /**
         * When closing, stop the process if it is active
         */ 
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.StopProcess();
        }

        /**
         * Once form is loaded, create and initialize presenter
         */
        private void MainForm_OnLoad(object sender, System.EventArgs e)
        {
            try
            {
                _presenter = new Presenters.MainPresenter(this, new FileDataHandler());
                AddCheckAllCheckbox();
            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        private void MainForm_OnShown(object sender, EventArgs e)
        {
            try
            {
                //As soon as the window is visible, init 
                //This is done this way to avoid exceptions in constructors
                _presenter.Init();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void ShowColoredTextMessage(string msg, Color color)
        {
            this.BeginInvoke
            (new MethodInvoker(()=>{
                //Selection color is restored after printing
                Color oldColor = rtbMessageLog.SelectionColor;
                rtbMessageLog.SelectionColor = color;
                rtbMessageLog.AppendText(msg + Environment.NewLine);
                rtbMessageLog.SelectionColor = oldColor;
            }));
            
        }

    }
}
