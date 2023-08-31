using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Enderun
{
    public partial class CloseForm : Form
    {
        private IConfigurationSection? systemMessages = Program.Configuration.GetSection("SystemMessages");
        public CloseForm()
        {
            InitializeComponent();
        }

        private void CloseForm_Load(object sender, EventArgs e)
        {
 
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Log.Information(systemMessages?.GetSection("E2").Value);
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
