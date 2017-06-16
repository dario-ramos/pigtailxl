using NJCourts.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using NJCourts.Models;
using ComponentFactory.Krypton.Toolkit;

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
                dgvCounties.Rows.Add(county.Name, county.Code, county.Processed? "Done" : "");
            }
        }

        /**
         * Only set filter checkbox as checked if both dates are set
         */
        public void SetDateFilter(DateTime? dateFiledFrom, DateTime? dateFiledTo)
        {
            if(dateFiledFrom.HasValue)
            {
                txtDateFiledFrom.Text = dateFiledFrom.Value.ToString("dd/mm/yyyy");
            }
            if (dateFiledTo.HasValue)
            {
                txtDateFiledTo.Text = dateFiledTo.Value.ToString("dd/mm/yyyy");
            }
            cbDateFilter.Checked = dateFiledFrom.HasValue && dateFiledTo.HasValue;
        }

        /**
         * Place zip code filter values on the UI. Overwrite everything, don't append
         */
        public void SetZipCodeFilters(List<int> zipCodeFilters)
        {
            rtbZipCodeFilters.Text = string.Join(",", zipCodeFilters);
            cbZipCodeFilters.Checked = zipCodeFilters.Count > 0;
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
         * Print an error message
         */
        private void HandleError(Exception ex)
        {
            ShowErrorMessage("ERROR: " + ex.Message);
        }

        /**
         * Once form is loaded, create and initialize presenter
         */
        private void MainForm_OnLoad(object sender, System.EventArgs e)
        {
            try
            {
                _presenter = new Presenters.Presenter(this);
                _presenter.Init();
            }catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        private void ShowColoredTextMessage(string msg, Color color)
        {
            Color oldColor = rtbMessageLog.SelectionColor;
            rtbMessageLog.SelectionColor = color;
            rtbMessageLog.AppendText(msg + Environment.NewLine);
            rtbMessageLog.SelectionColor = oldColor;
        }

    }
}
