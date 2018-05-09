using ComponentFactory.Krypton.Toolkit;
using NJCourts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NJCourts.Views
{
    public partial class CourtsForm : KryptonForm, ICourtsView
    {
        private Presenters.CourtsPresenter _presenter;
        private FileDataHandler _fileDataHandler;

        public CourtsForm(FileDataHandler fileDataHandler)
        {
            InitializeComponent();
            gbCaseFiledDate.BackColor = Color.Azure;
            gbCaseFiledDate.ForeColor = Color.Azure;
            _fileDataHandler = fileDataHandler;
        }

        /// <summary>
        /// If new value exists, select list. Otherwise, default to "New List" placeholder
        /// </summary>
        public string CurrentZipList
        {
            set
            {
                BeginInvoke((Action)(() =>
                {
                    if (cmbPredefinedZipLists.Items.Contains(value))
                    {
                        cmbPredefinedZipLists.SelectedItem = value;
                    }
                    else
                    {
                        cmbPredefinedZipLists.SelectedItem = Constants.Placeholders.NEW_ZIP_LIST;
                    }
                }));
            }
        }

        /// <summary>
        /// Display all allowed venue values for user selection
        /// </summary>
        /// <param name="venues">List of possible venues</param>
        public void LoadVenueFilter(List<string> venues)
        {
            BeginInvoke((Action)(() =>
            {
                cmbVenueFilter.Items.Clear();
                cmbVenueFilter.Items.AddRange(venues.ToArray());
            }));
        }

        /// <summary>
        /// Display an error message. It's appended, so older ones are kept
        /// Save current color, set to red, print and restore
        /// </summary>
        /// <param name="errorMsg">Plain text error message</param>
        public void ShowErrorMessage(string errorMsg)
        {
            BeginInvoke((Action)(() =>
            {
                ShowColoredTextMessage(errorMsg, Color.Red);
            }));
        }

        /// <summary>
        /// Render courts data, applying filters and sorting
        /// </summary>
        /// <param name="data">Court data rows</param>
        public void UpdateCourtsData(DataTable data)
        {
            BeginInvoke((Action)(() =>
            {
                var bSource = new BindingSource();
                bSource.DataSource = data;
                dgvCourts.DataSource = bSource;
                dgvCourts.Columns[Constants.FieldNames.NEW_RECORD_FLAG].Visible = false;
                dgvCourts.Sort(dgvCourts.Columns[Constants.DisplayFieldNames.DATE_TIME_OF_CREATION], System.ComponentModel.ListSortDirection.Descending);
            }));
        }

        public void UpdateZipFilter(List<string> zipValues)
        {
            BeginInvoke((Action)(() =>
            {
                txtZipFilter.Clear();
                txtZipFilter.Text = string.Join(Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR.ToString(), zipValues.ToArray());
            }));
        }

        /// <summary>
        /// Update zip lists by name
        /// </summary>
        /// <param name="zipListNames">List names</param>
        public void UpdateZipLists(IEnumerable<string> zipListNames)
        {
            BeginInvoke((Action)(() =>
            {
                cmbPredefinedZipLists.Items.Clear();
                cmbPredefinedZipLists.Items.AddRange(zipListNames.ToArray());
            }));
        }

        private void ApplyFilter()
        {
            pgbReadingDatabase.Visible = true;
            bgwReadingDatabase.RunWorkerAsync();
        }

        private void BgwMarkingRecords_OnDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(10);
            var recordIds = from DataGridViewRow r in dgvCourts.Rows
                            where r != null && r.Visible
                            select (int)r.Cells[Constants.DisplayFieldNames.ID].Value;
            worker.ReportProgress(20);
            _presenter.MarkRecordsAsOld(recordIds);
            worker.ReportProgress(90);
            _presenter.ReadFromDatabase();
            worker.ReportProgress(100);
        }

        private void BgwMarkingRecords_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbMarkingRecords.Value = e.ProgressPercentage;
        }

        private void BgwMarkingRecords_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnMarkRecordsAsOld.Enabled = true;
            pgbMarkingRecords.Visible = false;
        }

        private void BgwReadingDatabase_OnDoWork(object sender, DoWorkEventArgs e)


        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(50);
            _presenter.ReadFromDatabase();
            worker.ReportProgress(100);
        }

        private void BgwReadingDatabase_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbReadingDatabase.Value = e.ProgressPercentage;
        }

        private void BgwReadingDatabase_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbReadingDatabase.Visible = false;
        }

        private void BtnDeleteZipList_OnClick(object sender, EventArgs e)
        {
            _presenter.DeleteCurrentZipList();
        }

        private void BtnExport_OnClick(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _presenter.Export(dialog.FileName);
                }
            }
        }

        private void BtnFilter_OnClick(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void BtnMarkRecordsAsOld_OnClick(object sender, EventArgs e)
        {
            if( ! bgwMarkingRecords.IsBusy)
            {
                btnMarkRecordsAsOld.Enabled = false;
                pgbMarkingRecords.Value = 0;
                pgbMarkingRecords.Visible = true;
                bgwMarkingRecords.RunWorkerAsync();
            }
        }

        private void BtnSaveZipList_OnClick(object sender, EventArgs e)
        {
            string listName = cmbPredefinedZipLists.Text;
            if (string.IsNullOrWhiteSpace(listName))
            {
                MessageBox.Show("Cannot save list with an empty name");
                return;
            }
            if(listName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("List name cannot contain the following characters: " + string.Join(",", Path.GetInvalidFileNameChars()));
                return;
            }
            _presenter.SaveZipList((string)cmbPredefinedZipLists.Text, txtZipFilter.Text);
        }

        private void CbShowAllRecords_OnCheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as KryptonCheckBox;
            if (checkBox.Checked)
            {
                _presenter.DisableComparisonFilter(Constants.FieldNames.NEW_RECORD_FLAG);
            }
            else
            {
                _presenter.SetFilterParameters(Constants.FieldNames.NEW_RECORD_FLAG, true);
            }
            ApplyFilter();
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

        private void CmbPredefinedZipLists_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var zipListCombo = (KryptonComboBox)sender;
            string selectedZipList = (string)zipListCombo.SelectedItem;
            _presenter.CurrentZipList = selectedZipList;
            btnDeleteZipList.Enabled = ! selectedZipList.Equals(Constants.Placeholders.NEW_ZIP_LIST);
        }

        private void CmbVenueFilter_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var venueCombo = (KryptonComboBox)sender;
            string selectedVenue = (string)venueCombo.SelectedItem;
            _presenter.SetFilterParameters(Constants.FieldNames.VENUE, selectedVenue);
        }

        private void CourtsForm_OnLoad(object sender, System.EventArgs e)
        {
            _presenter = new Presenters.CourtsPresenter(this, _fileDataHandler);
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

        private void DtpCaseFiledDate1_ValueChanged(object sender, EventArgs e)
        {
            OnCaseFiledDateFilterChanged();
        }

        private void DtpCaseFiledDate2_ValueChanged(object sender, EventArgs e)
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
            _presenter.SetFilterParameters(Constants.FieldNames.CASE_FILED_DATE, comparison, value1, value2);
        }

        private void OnDemandAmountFilterChanged()
        {
            Constants.Comparison comparison = Constants.ComparisonFromString((string)cmbDemandAmountComparison.SelectedItem);
            string value1 = txtDemandAmountValue1.Text;
            string value2 = txtDemandAmountValue2.Text;
            _presenter.SetFilterParameters(Constants.FieldNames.DEMAND_AMOUNT, comparison, value1, value2);
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
            UpdateFilterTextField(sender, Constants.FieldNames.CASE_STATUS);
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
            UpdateFilterTextField(sender, Constants.FieldNames.DEBTOR_CITY);
        }

        private void TxtDocketValueFilter_OnTextChanged(object sender, EventArgs e)
        {
            UpdateFilterTextField(sender, Constants.FieldNames.DOCKET_VALUE);
        }

        private void TxtStateFilter_OnTextChanged(object sender, EventArgs e)
        {
            UpdateFilterTextField(sender, Constants.FieldNames.DEBTOR_STATE);
        }

        private void TxtZipFilter_OnTextChanged(object sender, EventArgs e)
        {
            KryptonRichTextBox textControl = (KryptonRichTextBox)sender;
            List<string> zips = textControl.Text.Split(Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR).Select(s => s.Trim()).ToList();
            _presenter.SetFilterParameters(Constants.FieldNames.DEBTOR_ZIP, zips);
        }

        private void UpdateFilterTextField(object sender, string fieldName)
        {
            KryptonTextBox textControl = (KryptonTextBox)sender;
            string textToSearch = textControl.Text;
            _presenter.SetFilterParameters(fieldName, textToSearch);
        }

    }
}
