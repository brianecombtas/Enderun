using Microsoft.VisualBasic;
using Interop.QBFC16;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Runtime;
using Serilog;
using static Enderun.Form1;
using System.Text;
using System.Net.Http;
using System.Net;

namespace Enderun
{
    public partial class Form1 : Form
    {
        public bool isClose = false;
        public static IConfiguration Configuration;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectQB_Click(object sender, EventArgs e)
        {
            ConnectToQuickbooks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var systemMessages = Program.Configuration.GetSection("SystemMessages");
            this.Text = systemMessages.GetSection("A1").Value;
            EnableAllControls(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm closeAppForm = new CloseForm();
            DialogResult result = closeAppForm.ShowDialog();
            var systemMessages = Program.Configuration.GetSection("SystemMessages");

            if (result == DialogResult.Yes)
            {
                // Close the session and connection with QuickBooks
                QBSessionManager sessionManager = new QBSessionManager();
                sessionManager.EndSession();
                sessionManager.CloseConnection();
                Log.Information(systemMessages.GetSection("E2").Value);
                Application.Exit();
            }
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            switch (cmbType.SelectedIndex)
            {
                case 0:
                    Bill bills = new Bill();
                    bills.DoBillAdd();
                    break;

                default:
                    JournalEntry journalEntry = new JournalEntry();
                    journalEntry.DoAccountAdd();
                    break;
            }
        }

        #region "testing"
        ////try
        ////{
        ////    var systemMessages = Program.Configuration.GetSection("SystemMessages");
        ////    var baseURL = systemMessages.GetSection("APIBaseURL").Value;
        ////    var journal = systemMessages.GetSection("API1:APIJournal").Value;

        ////    using (var httpClient = new HttpClient())
        ////    {
        ////        httpClient.BaseAddress = new Uri(baseURL);

        ////        var response = await httpClient.GetAsync(journal);
        ////        response.EnsureSuccessStatusCode();

        ////        string responseBody = await response.Content.ReadAsStringAsync();
        ////        if (response.StatusCode.ToString() == "OK")
        ////        {
        ////            txtPath.Text = responseBody;
        ////            Log.Information($"API request successful: {responseBody}");
        ////        }
        ////        else
        ////        {
        ////            txtPath.Text = responseBody;
        ////            Log.Error($"API request failed: {response.StatusCode.ToString()}");
        ////        }
        ////    }
        ////}
        ////catch (HttpRequestException ex)
        ////{
        ////    // Handle any exceptions that occurred during the API request
        ////    Log.Error($"API request failed: {ex.Message}");
        ////}
        ////break;
        #endregion

        private void btnCopyPath_Click(object sender, EventArgs e)
        {
            var systemMessages = Program.Configuration.GetSection("SystemMessages");
            lblStatus.Text = systemMessages.GetSection("A3").Value;
            Clipboard.SetText(txtPath.Text);
        }

        public void ConnectToQuickbooks()
        {
            bool sessionBegun = false;
            QBSessionManager sessionManager = new QBSessionManager();
            var systemMessages = Program.Configuration.GetSection("SystemMessages");

            try
            {
                // We want to know if we begun a session so we can end it if an
                // error happens
                sessionManager.OpenConnection("", systemMessages.GetSection("A1").Value);
                Log.Information(systemMessages.GetSection("A1").Value);
                sessionManager.BeginSession("", ENOpenMode.omDontCare);
                sessionBegun = true;

                //Send the request and get the response from QuickBooks
                //IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                if (sessionBegun)
                {
                    lblStatus.Text = systemMessages.GetSection("A2").Value;
                    EnableAllControls(true);
                    Log.Information(systemMessages.GetSection("A1").Value);
                }

                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionBegun = false;
                sessionManager.CloseConnection();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message.ToString();
                Log.Error(ex.Message.ToString() + systemMessages.GetSection("E1").Value + ex.StackTrace + systemMessages.GetSection("E2").Value);
                if (sessionBegun)
                {
                    sessionManager.EndSession();
                    sessionManager.CloseConnection();
                }
            }
        }

        public void EnableAllControls(bool isEnabled)
        {
            cmbType.Enabled = isEnabled;
            btnCopyPath.Enabled = isEnabled;
            btnExecute.Enabled = isEnabled;
            btnDownload.Enabled = isEnabled;
            btnCopyPath.Enabled = isEnabled;
            txtPath.Enabled = isEnabled;
        }
    }
}