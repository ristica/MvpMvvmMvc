namespace Demo.Views
{
    partial class FrmErrorMessage
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
            this.tbErrorMessage = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbErrorMessage
            // 
            this.tbErrorMessage.Location = new System.Drawing.Point(12, 12);
            this.tbErrorMessage.Multiline = true;
            this.tbErrorMessage.Name = "tbErrorMessage";
            this.tbErrorMessage.Size = new System.Drawing.Size(498, 147);
            this.tbErrorMessage.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(260, 165);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(122, 28);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopyClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(388, 165);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClicked);
            // 
            // FrmErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 205);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tbErrorMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmErrorMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error Messages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbErrorMessage;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClose;
    }
}