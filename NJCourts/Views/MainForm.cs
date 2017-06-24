using NJCourts.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using NJCourts.Models;
using ComponentFactory.Krypton.Toolkit;
using System.Linq;
using System.Globalization;

namespace NJCourts
{
    /**
     * Application main and only form
     */
    public partial class MainForm : KryptonForm, IView
    {
        private Presenters.Presenter _presenter;

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
            set
            {
                btnStartStopProcess.Text = value ? "Stop Process" : "Start Process";
                btnStartStopProcess.Enabled = true;
                btnApplyFilters.Enabled = !value;
            }
        }

        public List<int> ZipCodeFilters
        {
            get
            {
                return rtbZipCodeFilters.Text.Split(',').Select(Int32.Parse).ToList();
            }
            set
            {
                rtbZipCodeFilters.Text = string.Join(",", value);
                cbZipCodeFilters.Checked = value.Count > 0;
            }
        }

        /**
         * Only set filter checkbox as checked if both dates are set
         * From: Item1, To: Item2
         */
        public Tuple<DateTime?, DateTime?> DateFilter
        {
            get
            {
                DateTime? dateFrom = null;
                DateTime? dateTo = null;
                if (dtpDateFrom.Checked)
                {
                    dateFrom = dtpDateFrom.Value;
                }
                if (dtpDateTo.Checked)
                {
                    dateTo = dtpDateTo.Value;
                }
                return new Tuple<DateTime?, DateTime?>(dateFrom, dateTo);
            }
            set
            {
                var dateFiledFrom = value.Item1;
                var dateFiledTo = value.Item2;
                if (dateFiledFrom.HasValue)
                {
                    dtpDateFrom.Value = dateFiledFrom.Value;
                }
                if (dateFiledTo.HasValue)
                {
                    dtpDateTo.Value = dateFiledTo.Value;
                }
                cbDateFilter.Checked = dateFiledFrom.HasValue && dateFiledTo.HasValue;
            }
        }

        /**
         * Fill the grid with county data
         */
        public void SetCounties(List<County> counties)
        {
            counties.Sort(delegate (County c1, County c2) { return c1.Name.CompareTo(c2.Name); });
            foreach(County county in counties)
            {
                dgvCounties.Rows.Add(county.Name, county.Code, county.Processed? "Processed" : "");
            }
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

        /**
         * Delegate to presenter
         */
        private void BtnApplyFilters_OnClick(object sender, EventArgs e)
        {
            _presenter.ApplyFilters();
        }

        /**
         * Delegate to presenter
         */
        private void BtnStartStopProcess_OnClick(object sender, EventArgs e)
        {
            try
            {
                _presenter.StartStopProcess();
            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        /**
         * Only allow editing filters when check is set
         */
        private void CbDateFilter_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpDateFrom.Enabled = cbDateFilter.Checked;
                dtpDateTo.Enabled = cbDateFilter.Checked;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        /**
         * Only allow editing filters when check is set
         */
        private void CbZipCodeFilters_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rtbZipCodeFilters.ReadOnly = !cbZipCodeFilters.Checked;
            }
            catch (Exception ex)
            {
                HandleError(ex);
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
                _presenter = new Presenters.Presenter(this);
            }catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        /**
         * As soon as the window is visible, init everything
         */
        private void MainForm_OnShown(object sender, EventArgs e)
        {
            try
            {
                _presenter.Init();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        /**
         * Selection color is restored after printing
         */ 
        private void ShowColoredTextMessage(string msg, Color color)
        {
            this.BeginInvoke
            (new MethodInvoker(()=>{
                Color oldColor = rtbMessageLog.SelectionColor;
                rtbMessageLog.SelectionColor = color;
                rtbMessageLog.AppendText(msg + Environment.NewLine);
                rtbMessageLog.SelectionColor = oldColor;
            }));
            
        }

    }
}
