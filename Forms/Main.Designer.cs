namespace Enderun
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnConnectQB = new Button();
            txtPath = new TextBox();
            btnCopyPath = new Button();
            btnExecute = new Button();
            btnClose = new Button();
            btnDownload = new Button();
            cmbType = new ComboBox();
            pictureBox1 = new PictureBox();
            btnLogs = new Button();
            btnBrowse = new Button();
            cmbCountry = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnConnectQB
            // 
            btnConnectQB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnectQB.Location = new Point(501, 12);
            btnConnectQB.Name = "btnConnectQB";
            btnConnectQB.Size = new Size(175, 30);
            btnConnectQB.TabIndex = 1;
            btnConnectQB.Text = "Connect to QuickBooks";
            btnConnectQB.UseVisualStyleBackColor = true;
            btnConnectQB.Click += btnConnectQB_Click;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.Location = new Point(12, 101);
            txtPath.Margin = new Padding(3, 2, 3, 2);
            txtPath.Multiline = true;
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(566, 41);
            txtPath.TabIndex = 2;
            txtPath.TextChanged += txtPath_TextChanged;
            // 
            // btnCopyPath
            // 
            btnCopyPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyPath.BackgroundImage = (Image)resources.GetObject("btnCopyPath.BackgroundImage");
            btnCopyPath.BackgroundImageLayout = ImageLayout.Stretch;
            btnCopyPath.Location = new Point(555, 100);
            btnCopyPath.Name = "btnCopyPath";
            btnCopyPath.Size = new Size(23, 23);
            btnCopyPath.TabIndex = 8;
            btnCopyPath.UseVisualStyleBackColor = true;
            btnCopyPath.Click += btnCopyPath_Click;
            // 
            // btnExecute
            // 
            btnExecute.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExecute.BackgroundImage = (Image)resources.GetObject("btnExecute.BackgroundImage");
            btnExecute.BackgroundImageLayout = ImageLayout.Zoom;
            btnExecute.Location = new Point(584, 101);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(42, 41);
            btnExecute.TabIndex = 9;
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(563, 170);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(111, 30);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownload.BackgroundImage = (Image)resources.GetObject("btnDownload.BackgroundImage");
            btnDownload.BackgroundImageLayout = ImageLayout.Zoom;
            btnDownload.Location = new Point(632, 101);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(42, 41);
            btnDownload.TabIndex = 13;
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // cmbType
            // 
            cmbType.BackColor = SystemColors.Window;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Journal Entries", "Bills", "Journal Entries (API)", "Bills (API)" });
            cmbType.Location = new Point(12, 73);
            cmbType.MaxDropDownItems = 5;
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(230, 23);
            cmbType.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // btnLogs
            // 
            btnLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogs.Location = new Point(446, 170);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(111, 30);
            btnLogs.TabIndex = 17;
            btnLogs.Text = "System Logs";
            btnLogs.UseVisualStyleBackColor = true;
            btnLogs.Click += btnLogs_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(248, 73);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 18;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // cmbCountry
            // 
            cmbCountry.BackColor = SystemColors.Window;
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(382, 15);
            cmbCountry.MaxDropDownItems = 5;
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(113, 23);
            cmbCountry.TabIndex = 19;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 207);
            Controls.Add(cmbCountry);
            Controls.Add(btnBrowse);
            Controls.Add(btnLogs);
            Controls.Add(pictureBox1);
            Controls.Add(cmbType);
            Controls.Add(btnDownload);
            Controls.Add(btnClose);
            Controls.Add(btnExecute);
            Controls.Add(btnCopyPath);
            Controls.Add(txtPath);
            Controls.Add(btnConnectQB);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnConnectQB;
        private TextBox txtPath;
        private Button btnCopyPath;
        private Button btnExecute;
        private Button btnClose;
        private Button btnDownload;
        private ComboBox cmbType;
        private PictureBox pictureBox1;
        private Button btnLogs;
        private Button btnBrowse;
        private ComboBox cmbCountry;
    }
}