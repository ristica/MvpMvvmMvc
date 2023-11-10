using System;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.Views.Contracts.Views;

namespace Demo.Views
{
    public partial class FrmHelp : Form, IFrmHelp
    {
        private readonly IEventHelper _eventHelper;

        public event EventHandler FormLoadEventRaised;
        public event EventHandler FormCloseEventRaised;

        public string WindowTitle
        {
            get => this.Text;
            set => this.Text = value;
        }

        public string Product
        {
            get => this.lblProductInfo.Text;
            set => lblProductInfo.Text = value;
        }

        public string Version
        {
            get => this.lblVersion.Text;
            set => this.lblVersion.Text = value;
        }

        public string Copyright
        {
            get => this.lblCopyright.Text;
            set => this.lblCopyright.Text = value;
        }

        public string Description
        {
            get => this.lblDescription.Text; 
            set => this.lblDescription.Text = value;
        }

        public FrmHelp(IEventHelper eventHelper)
        {
            this._eventHelper = eventHelper; 

            InitializeComponent();
        }

        public void ShowMe()
        {
            if (!string.IsNullOrEmpty(this.WindowTitle)) this.Text = this.WindowTitle;
            this.Show();
        }

        private void FrmHelpOnLoad(object sender, EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, FormLoadEventRaised, e);
        }

        private void BtnCloseOnClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHelpOnClosing(object sender, FormClosingEventArgs e)
        {
            this._eventHelper.RaiseEvent(this, FormCloseEventRaised, e);
        }
    }
}
