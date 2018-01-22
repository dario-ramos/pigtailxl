using ComponentFactory.Krypton.Toolkit;
using NJCourts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NJCourts.Views
{
    public partial class CourtsForm : KryptonForm, ICourtsView
    {
        private Presenters.CourtsPresenter _presenter;

        public CourtsForm()
        {
            InitializeComponent();
            gbCaseFiledDate.BackColor = Color.Azure;
            gbCaseFiledDate.ForeColor = Color.Azure;
        }

        /// <summary>
        /// Display all allowed venue values for user selection
        /// </summary>
        /// <param name="venues">List of possible venues</param>
        public void LoadVenueFilter(List<string> venues)
        {
            cmbVenueFilter.Items.Clear();
            cmbVenueFilter.Items.AddRange(venues.ToArray());
        }

        /**
         * Display an error message. It's appended, so older ones are kept
         * Save current color, set to red, print and restore
         */
        public void ShowErrorMessage(string errorMsg)
        {
            ShowColoredTextMessage(errorMsg, Color.Red);
        }

        public void UpdateCourtsData(DataTable data)
        {
            var bSource = new BindingSource();
            bSource.DataSource = data;
            dgvCourts.DataSource = bSource;
            dgvCourts.Sort(dgvCourts.Columns[Constants.DisplayFieldNames.DATE_TIME_OF_CREATION], System.ComponentModel.ListSortDirection.Descending);
        }

        private void BtnExport_OnClick(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _presenter.Export(dialog.FileName);
                }
            }
        }

        private void BtnFilter_OnClick(object sender, EventArgs e)
        {
            BindingSource bSource = (BindingSource)dgvCourts.DataSource;
            bSource.Filter = _presenter.Filter;
        }

        private void CmbCaseFiledDateComparison_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            dtpCaseFiledDate2.Enabled = (Constants.ComparisonFromString((string)cmbCaseFiledDateComparison.SelectedItem) == Constants.Comparison.RANGE);
            OnCaseFiledDateFilterChanged();
        }

        private void CmbDemandAmountComparison_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Constants.Comparison comparison = Constants.ComparisonFromString((string)cmbDemandAmountComparison.SelectedItem);
            txtDemandAmountValue1.Enabled = comparison != Constants.Comparison.NONE;
            txtDemandAmountValue2.Enabled = comparison == Constants.Comparison.RANGE;
            OnDemandAmountFilterChanged();
        }

        private void CmbVenueFilter_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var venueCombo = (KryptonComboBox)sender;
            string selectedVenue = (string)venueCombo.SelectedItem;
            _presenter.SetFilterParameters(Constants.DisplayFieldNames.VENUE, selectedVenue);
        }

        private void CourtsForm_OnLoad(object sender, System.EventArgs e)
        {
            _presenter = new Presenters.CourtsPresenter(this);
        }

        private void CourtsForm_OnShown(object sender, System.EventArgs e)
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

        private void dtpCaseFiledDate1_ValueChanged(object sender, EventArgs e)
        {
            OnCaseFiledDateFilterChanged();
        }

        private void dtpCaseFiledDate2_ValueChanged(object sender, EventArgs e)
        {
            OnCaseFiledDateFilterChanged();
        }

        private void HandleError(Exception ex)
        {
            ShowErrorMessage("ERROR: " + ex.Message);
        }

        private void OnCaseFiledDateFilterChanged()
        {
            Constants.Comparison comparison = Constants.ComparisonFromString((string)cmbCaseFiledDateComparison.SelectedItem);
            dtpCaseFiledDate1.Enabled = comparison != Constants.Comparison.NONE;
            dtpCaseFiledDate2.Enabled = comparison == Constants.Comparison.RANGE;
            string value1 = dtpCaseFiledDate1.Text;
            string value2 = dtpCaseFiledDate2.Text;
            _presenter.SetFilterParameters(Constants.DisplayFieldNames.CASE_FILED_DATE, comparison, value1, value2);
        }

        private void OnDemandAmountFilterChanged()
        {
            Constants.Comparison comparison = Constants.ComparisonFromString((string)cmbDemandAmountComparison.SelectedItem);
            string value1 = txtDemandAmountValue1.Text;
            string value2 = txtDemandAmountValue2.Text;
            _presenter.SetFilterParameters(Constants.DisplayFieldNames.DEMAND_AMOUNT, comparison, value1, value2);
        }

        private void ShowColoredTextMessage(string msg, Color color)
        {
            this.BeginInvoke
            (new MethodInvoker(() => {
                MessageBox.Show(msg);
            }));
        }

        private void TxtCaseStatusFilter_OnTextChanged(object sender, EventArgs e)
        {
            UpdateFilterTextField(sender, Constants.DisplayFieldNames.CASE_STATUS);
        }

        private void TxtDemandAmountValue1_OnTextChanged(object sender, EventArgs e)
        {
            OnDemandAmountFilterChanged();
        }

        private void TxtDemandAmountValue2_OnTextChanged(object sender, EventArgs e)
        {
            OnDemandAmountFilterChanged();
        }

        private void TxtCityFilter_OnTextChanged(object sender, EventArgs e)
        {
            UpdateFilterTextField(sender, Constants.DisplayFieldNames.DEBTOR_CITY);
        }

        private void TxtDocketValueFilter_OnTextChanged(object sender, EventArgs e)
        {
            UpdateFilterTextField(sender, Constants.DisplayFieldNames.DOCKET_VALUE);
        }

        private void TxtStateFilter_OnTextChanged(object sender, EventArgs e)
        {
            UpdateFilterTextField(sender, Constants.DisplayFieldNames.DEBTOR_STATE);
        }

        private void TxtZipFilter_OnTextChanged(object sender, EventArgs e)
        {
            KryptonRichTextBox textControl = (KryptonRichTextBox)sender;
            List<string> zips = textControl.Text.Split(Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR).Select(s => s.Trim()).ToList();
            _presenter.SetFilterParameters(Constants.DisplayFieldNames.DEBTOR_ZIP, zips);
        }

        private void UpdateFilterTextField(object sender, string fieldName)
        {
            KryptonTextBox textControl = (KryptonTextBox)sender;
            string textToSearch = textControl.Text;
            _presenter.SetFilterParameters(fieldName, textToSearch);
        }

    }
}
