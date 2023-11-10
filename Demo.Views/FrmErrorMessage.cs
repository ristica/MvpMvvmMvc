using System;
using Demo.Views.Contracts.Views;
using System.Windows.Forms;

namespace Demo.Views
{
    public partial class FrmErrorMessage : Form, IFrmErrorMessage
    {
        public event EventHandler FormLoadEventRaised;
        public event EventHandler FormCloseEventRaised;

        public string WindowTitle { get; set; }

        public string ErrorMessage { get; set; }

        public FrmErrorMessage()
        {
            InitializeComponent();
        }

        private void BtnCopyClicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbErrorMessage.Text)) return;
            Clipboard.SetText(this.tbErrorMessage.Text);
        }

        private void BtnCloseClicked(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public void ShowMe()
        {
            if (!string.IsNullOrEmpty(this.WindowTitle)) this.Text = this.WindowTitle;
            this.tbErrorMessage.Text = this.ErrorMessage;

            this.Show();
        }
    }
}
