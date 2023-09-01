using Interop.QBFC16;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Enderun
{
    public partial class Form1 : Form
    {
        public bool isClose = false;
        private IConfigurationSection? systemMessages = Program.Configuration.GetSection("SystemMessages");
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
            this.Text = systemMessages?.GetSection("A1").Value;
            EnableAllControls(false);
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(btnExecute, "Execute the chosen report");
            tooltip.SetToolTip(btnDownload, "Download the report");
            tooltip.SetToolTip(btnCopyPath, "Copy to clipboard");
            btnCopyPath.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm closeAppForm = new CloseForm();
            DialogResult result = closeAppForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                // Close the session and connection with QuickBooks
                QBSessionManager sessionManager = new QBSessionManager();
                sessionManager.EndSession();
                sessionManager.CloseConnection();
                Log.Information(systemMessages?.GetSection("E2").Value);
                Application.Exit();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex < 0)
            {
                MessageBox.Show(systemMessages?.GetSection("A5").Value);
                return;
            }

            switch (cmbType.SelectedIndex)
            {
                case 0:
                    JournalEntry journalEntry = new JournalEntry();
                    journalEntry.DoAccountAdd();
                    break;
                default:
                    Bill bills = new Bill();
                    bills.DoBillAdd();
                    break;
            }
        }

        #region "API testing"
        ////try
        ////{
        ////    var systemMessages? = Program.Configuration.GetSection("SystemMessages");
        ////    var baseURL = systemMessages?.GetSection("APIBaseURL").Value;
        ////    var journal = systemMessages?.GetSection("API1:APIJournal").Value;

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
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show(systemMessages?.GetSection("A3").Value);
                Clipboard.SetText(txtPath.Text);
            }
        }

        public void ConnectToQuickbooks()
        {
            bool sessionBegun = false;
            QBSessionManager sessionManager = new QBSessionManager();

            try
            {
                // We want to know if we begun a session so we can end it if an
                // error happens
                Log.Information(systemMessages?.GetSection("A4").Value);
                sessionManager.OpenConnection("", systemMessages?.GetSection("A1").Value);
                sessionManager.BeginSession("", ENOpenMode.omDontCare);
                sessionBegun = true;

                if (sessionBegun)
                {
                    EnableAllControls(true);
                    Log.Information(systemMessages?.GetSection("A2").Value);
                    MessageBox.Show(systemMessages?.GetSection("A2").Value);
                }

                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionBegun = false;
                sessionManager.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(systemMessages?.GetSection("E3").Value);
                Log.Error($"{systemMessages?.GetSection("E1").Value} : {ex.Message} : {ex.StackTrace}");
                if (sessionBegun)
                {
                    sessionManager.EndSession();
                    sessionManager.CloseConnection();
                }
            }
        }

        public void EnableAllControls(bool isEnabled = false)
        {
            cmbType.Enabled = isEnabled;
            btnCopyPath.Enabled = isEnabled;
            btnExecute.Enabled = isEnabled;
            btnDownload.Enabled = isEnabled;
            txtPath.Enabled = isEnabled;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text) && cmbType.SelectedIndex == -1)
                MessageBox.Show(systemMessages?.GetSection("A5").Value);

            return;
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                btnCopyPath.Enabled = true;
                return;
            }
        }
    }
}