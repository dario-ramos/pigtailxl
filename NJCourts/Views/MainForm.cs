using NJCourts.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NJCourts
{
    /**
     * Application main and only form
     */
    public partial class MainForm : Form, IView
    {
        private Presenters.Presenter _presenter;

        /**
         * Constructor: Initializes view 
         */
        public MainForm()
        {
            InitializeComponent();
        }

        /**
         * Display an error message. It's appended, so older ones are kept
         * Save current color, set to red, print and restore
         */ 
        public void ShowErrorMessage(string errorMsg)
        {
            Color oldColor = rtbMessageLog.SelectionColor;
            rtbMessageLog.SelectionColor = Color.Red;
            rtbMessageLog.AppendText(errorMsg + Environment.NewLine);
            rtbMessageLog.SelectionColor = oldColor;
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

    }
}
