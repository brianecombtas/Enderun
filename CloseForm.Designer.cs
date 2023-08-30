namespace Enderun
{
    partial class CloseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnYes = new Button();
            btnNo = new Button();
            lblCloseMessage = new Label();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.Location = new Point(98, 77);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(94, 29);
            btnYes.TabIndex = 0;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Location = new Point(198, 77);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(94, 29);
            btnNo.TabIndex = 1;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // lblCloseMessage
            // 
            lblCloseMessage.AutoSize = true;
            lblCloseMessage.Location = new Point(52, 40);
            lblCloseMessage.Name = "lblCloseMessage";
            lblCloseMessage.Size = new Size(312, 20);
            lblCloseMessage.TabIndex = 2;
            lblCloseMessage.Text = "Are you sure you want to exit the application?";
            // 
            // CloseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 147);
            Controls.Add(lblCloseMessage);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Name = "CloseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Combtas x Enderun";
            Load += CloseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnYes;
        private Button btnNo;
        private Label lblCloseMessage;
    }
}