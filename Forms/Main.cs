using Enderun.Logic;
using Interop.QBFC16;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Configuration;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using static Enderun.Models.InterfaceAPIModels;

namespace Enderun
{
    public partial class Main : Form
    {
        public bool isClose = false;
        private IConfigurationSection? systemMessages = Program.Configuration.GetSection("SystemMessages");
        private IConfigurationSection? apiConfig = Program.Configuration.GetSection("ApiConfig");
        private IConfigurationSection? versions = Program.Configuration.GetSection("CountryVersions");
        private readonly string logFolder = Program.Configuration.GetSection("LogFolder").Value;
        private JournalEntry journalEntry = new();
        private Bill bills = new();
        private JournalEntryProcess journalEntryProc = new();
        private BillProcess billsProc = new();
        public Main()
        {
            InitializeComponent();
        }

        private void btnConnectQB_Click(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex == 0)
            {
                MessageBox.Show(systemMessages?.GetSection("A11").Value);
                return;
            }

            ConnectToQuickbooks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = systemMessages?.GetSection("A1").Value;
            EnableAllControls();
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(btnExecute, systemMessages?.GetSection("A8").Value);
            tooltip.SetToolTip(btnDownload, systemMessages?.GetSection("A9").Value);
            tooltip.SetToolTip(btnCopyPath, systemMessages?.GetSection("A10").Value);
            btnCopyPath.Enabled = false;

            int versionCount = int.Parse(Program.Configuration.GetSection("CountryVersionsCount").Value);
            for (int q = 1; q <= versionCount; q++)
                cmbCountry.Items.Add(versions?.GetSection($"{q}").Value);

            cmbCountry.SelectedIndex = 0;
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
            try
            {
                var journalEntriesList = new List<AcctInterfaces>();
                var billsList = new List<AcctInterfaces>();
                var region = (string)cmbCountry.SelectedItem;

                if (cmbType.SelectedIndex < 0)
                {
                    MessageBox.Show(systemMessages?.GetSection("A5").Value);
                    return;
                }

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(apiConfig.GetSection("Url").Value).Result.Content.ReadAsStringAsync().Result;
                    var test = $"<head><script defer data-domain=\"emerald-arden-86.tiiny.site\" src=\"https://analytics.tiiny.site/js/plausible.js\"></script></head>";
                    response = response.Replace(test, string.Empty);
                    JObject jsonObject = JObject.Parse(response);
                    string acctInterfaces = jsonObject["AcctInterfaces"].ToString();
                    var mappedAcctInterface = JsonConvert.DeserializeObject<List<AcctInterfaces>>(acctInterfaces);

                    journalEntriesList = mappedAcctInterface.Where(q => q.LineType.Equals("C")).ToList();
                    billsList = mappedAcctInterface.Where(q => q.LineType.Equals("E")).ToList();
                }

                switch (cmbType.SelectedIndex)
                {
                    case 0:
                        journalEntry.DoAccountAdd(region);
                        break;
                    case 1:
                        bills.DoBillAdd(region);
                        break;
                    case 2:
                        journalEntryProc.DoAccountAdd(journalEntriesList, region);
                        break;
                    default:
                        billsProc.DoBillAdd(billsList, region);
                        break;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(systemMessages?.GetSection("E3").Value);
                Log.Error($"{systemMessages?.GetSection("E3").Value} : {err.Message} : {err.StackTrace}");
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
        ///////////////////////////////////////////////////////////////////////////////////////
        //////string jsonContent = File.ReadAllText("C:\\Users\\ComBtas\\Desktop\\Projects\\QuickBooks\\Enderun\\Enderun\\interfaceApi.json");
        //////// Deserialize JSON into your C# class
        //////AcctHeader apiResponse = JsonConvert.DeserializeObject<AcctHeader>(jsonContent);

        //var apParams = new APParams
        //{
        //    InvoiceAPNo = 0,
        //    CompUnitType = 1,
        //    CompUnitID = 1,
        //    Account = 1,
        //    CompanyID = 1,
        //    SupplierCode = "string",
        //    InvoiceSubType = "ALL",
        //    InvoiceNumber = "2",
        //    WorkerCode = "",
        //    DocDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
        //    InvoiceFromDate = DateTime.Now,
        //    InvoiceToDate = DateTime.Now
        //};

        //using (var httpClient = new HttpClient())
        //{
        //    httpClient.Timeout = TimeSpan.FromMinutes(int.Parse(apiConfig.GetSection("Timeout").Value));
        //    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiConfig.GetSection("Username").Value}:{apiConfig.GetSection("Password").Value}"));
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        //    var jsonPayload = JsonConvert.SerializeObject(apParams);
        //    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        //    httpClient.DefaultRequestHeaders.Add(apiConfig.GetSection("Key").Value, apiConfig.GetSection("Value").Value);
        //    var response = await httpClient.PostAsync(apiConfig.GetSection("Url").Value, content);

        //    string responseBody = await response.Content.ReadAsStringAsync();
        //    if (response.StatusCode.ToString() == "OK")
        //    {
        //        txtPath.Text = responseBody;
        //        Log.Information($"API request successful: {responseBody}");
        //    }
        //    else
        //    {
        //        txtPath.Text = responseBody;
        //        Log.Error($"API request failed: {responseBody}");
        //    }


        //////using (var httpClient = new HttpClient())
        //////{
        //////    var response = httpClient.GetAsync(apiConfig.GetSection("Url").Value).Result.Content.ReadAsStringAsync().Result;

        //////    JObject jsonObject = JObject.Parse(response);
        //////    string acctInterfaces = jsonObject["AcctInterfaces"].ToString();
        //////    var mappedAcctInterface = JsonConvert.DeserializeObject<List<AcctInterfaces>>(acctInterfaces);

        //////    var journalEntry = mappedAcctInterface.Where(q => q.LineType.Equals("C")).ToList();
        //////    var bill = mappedAcctInterface.Where(q => q.LineType.Equals("E")).ToList();
        //////}
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
            //cmbType.Enabled = isEnabled;
            //btnCopyPath.Enabled = isEnabled;
            //btnExecute.Enabled = isEnabled;
            //btnDownload.Enabled = isEnabled;
            //txtPath.Enabled = isEnabled;
            //btnLogs.Enabled = isEnabled;
            //btnBrowse.Enabled = isEnabled;

            foreach (Control c in this.Controls)
                c.Enabled = isEnabled;

            btnConnectQB.Enabled = !isEnabled;
            cmbCountry.Enabled = !isEnabled;
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


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            Log.Information(systemMessages?.GetSection("A7").Value);
            var filePath = $"{logFolder}\\{DateTime.Now.ToString("MM-dd-yyyy")}.log";
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show(systemMessages?.GetSection("E4").Value);
                    Log.Error($"{systemMessages?.GetSection("E4").Value}");
                    return;
                }

                // Check if the file is already open by another process
                Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(filePath));
                foreach (var process in processes)
                {
                    try
                    {
                        process.Kill(); // Kill the process if it's using the file
                    }
                    catch (Exception err)
                    {
                        Log.Error($"Error killing process:  {err.Message} : {err.StackTrace}");
                    }
                }

                // Open the file with the default associated program
                Log.Information(systemMessages?.GetSection("A7").Value);
                Process.Start("notepad.exe", filePath);
            }
            catch (Exception err)
            {
                Log.Error($"{err.Message} : {err.StackTrace}");
                return;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Process the selected Excel file
                    //ProcessExcelFile(filePath);
                }
            }
        }
    }
}