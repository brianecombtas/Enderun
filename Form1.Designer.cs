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
            lblStatus = new Label();
            btnConnectQB = new Button();
            txtPath = new TextBox();
            btnCopyPath = new Button();
            btnExecute = new Button();
            btnClose = new Button();
            btnDownload = new Button();
            cmbType = new ComboBox();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(12, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(79, 21);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Welcome!";
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
            // 
            // cmbType
            // 
            cmbType.BackColor = SystemColors.Window;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Journal Entries", "Bills" });
            cmbType.Location = new Point(12, 73);
            cmbType.MaxDropDownItems = 5;
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(230, 23);
            cmbType.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 207);
            Controls.Add(cmbType);
            Controls.Add(btnDownload);
            Controls.Add(btnClose);
            Controls.Add(btnExecute);
            Controls.Add(btnCopyPath);
            Controls.Add(txtPath);
            Controls.Add(btnConnectQB);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnConnectQB;
        private TextBox txtPath;
        private Button btnCopyPath;
        private Button btnExecute;
        private Button btnClose;
        private Button btnDownload;
        private ComboBox cmbType;
    }
}