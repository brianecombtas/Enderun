namespace Enderun
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnConnectQB = new Button();
            txtPath = new TextBox();
            btnCopyPath = new Button();
            btnExecute = new Button();
            btnClose = new Button();
            btnDownload = new Button();
            cmbType = new ComboBox();
            pictureBox1 = new PictureBox();
            btnLogs = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnConnectQB
            // 
            btnConnectQB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnectQB.Location = new Point(573, 16);
            btnConnectQB.Margin = new Padding(3, 4, 3, 4);
            btnConnectQB.Name = "btnConnectQB";
            btnConnectQB.Size = new Size(200, 40);
            btnConnectQB.TabIndex = 1;
            btnConnectQB.Text = "Connect to QuickBooks";
            btnConnectQB.UseVisualStyleBackColor = true;
            btnConnectQB.Click += btnConnectQB_Click;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.Location = new Point(14, 135);
            txtPath.Multiline = true;
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(646, 53);
            txtPath.TabIndex = 2;
            txtPath.TextChanged += txtPath_TextChanged;
            // 
            // btnCopyPath
            // 
            btnCopyPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyPath.BackgroundImage = (Image)resources.GetObject("btnCopyPath.BackgroundImage");
            btnCopyPath.BackgroundImageLayout = ImageLayout.Stretch;
            btnCopyPath.Location = new Point(634, 133);
            btnCopyPath.Margin = new Padding(3, 4, 3, 4);
            btnCopyPath.Name = "btnCopyPath";
            btnCopyPath.Size = new Size(26, 31);
            btnCopyPath.TabIndex = 8;
            btnCopyPath.UseVisualStyleBackColor = true;
            btnCopyPath.Click += btnCopyPath_Click;
            // 
            // btnExecute
            // 
            btnExecute.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExecute.BackgroundImage = (Image)resources.GetObject("btnExecute.BackgroundImage");
            btnExecute.BackgroundImageLayout = ImageLayout.Zoom;
            btnExecute.Location = new Point(667, 135);
            btnExecute.Margin = new Padding(3, 4, 3, 4);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(48, 55);
            btnExecute.TabIndex = 9;
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(643, 227);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(127, 40);
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
            btnDownload.Location = new Point(722, 135);
            btnDownload.Margin = new Padding(3, 4, 3, 4);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(48, 55);
            btnDownload.TabIndex = 13;
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // cmbType
            // 
            cmbType.BackColor = SystemColors.Window;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Journal Entries", "Bills" });
            cmbType.Location = new Point(14, 97);
            cmbType.Margin = new Padding(3, 4, 3, 4);
            cmbType.MaxDropDownItems = 5;
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(262, 28);
            cmbType.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // btnLogs
            // 
            btnLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogs.Location = new Point(510, 227);
            btnLogs.Margin = new Padding(3, 4, 3, 4);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(127, 40);
            btnLogs.TabIndex = 17;
            btnLogs.Text = "System Logs";
            btnLogs.UseVisualStyleBackColor = true;
            btnLogs.Click += btnLogs_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 276);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
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
    }
}