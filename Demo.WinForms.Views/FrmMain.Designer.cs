namespace Demo.WinForms.Views
{
    partial class FrmMain
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Location = new System.Drawing.Point(11, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(780, 400);
            this.pnlContent.TabIndex = 1;
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.White;
            this.btnCustomers.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCustomers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnCustomers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Location = new System.Drawing.Point(11, 20);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(80, 23);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.BtnCustomersOnClicked);
            // 
            // btnDepartments
            // 
            this.btnDepartments.BackColor = System.Drawing.Color.White;
            this.btnDepartments.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDepartments.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDepartments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDepartments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartments.Location = new System.Drawing.Point(90, 20);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(80, 23);
            this.btnDepartments.TabIndex = 3;
            this.btnDepartments.Text = "Departments";
            this.btnDepartments.UseVisualStyleBackColor = false;
            this.btnDepartments.Click += new System.EventHandler(this.BtnDepartmentsOnClicked);
            // 
            // pbInfo
            // 
            this.pbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInfo.Image = global::Demo.WinForms.Views.Resource1.help;
            this.pbInfo.Location = new System.Drawing.Point(760, 8);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(31, 31);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInfo.TabIndex = 4;
            this.pbInfo.TabStop = false;
            this.pbInfo.Tag = "Assembly Infos";
            this.pbInfo.Click += new System.EventHandler(this.PictureBoxInfoOnClicked);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 455);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pbInfo);
            this.Controls.Add(this.btnDepartments);
            this.Controls.Add(this.btnCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MVP with IoC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainOnClosing);
            this.Load += new System.EventHandler(this.FrmMainOnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.PictureBox pbInfo;
    }
}

