using System;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Views.Contracts.UserControls;

namespace Demo.Views.UserControls
{
    // ReSharper disable once InconsistentNaming
    public partial class CustomerRowUC : UserControl, ICustomerRowUC
    {
        #region FIELDS

        private readonly IEventHelper _eventHelper;
        private ICustomerModel _dataContext;

        #endregion

        #region PROPERTIES

        public ICustomerModel DataContext
        {
            get => this._dataContext;
            set
            {
                this._dataContext = value;
                this.RefreshLayout();
            }
        }

        #endregion

        #region EVENTS

        public event EventHandler CustomerRowUserControlEditEventRaised;
        public event EventHandler CustomerRowUserControlDeleteEventRaised;
        public event EventHandler CustomerRowUserControlDisposeEventRaised;

        #endregion

        #region C-TRO

        public CustomerRowUC(IEventHelper eventHelper)
        {
            this._eventHelper = eventHelper;

            InitializeComponent();
        }

        #endregion

        #region METHODS

        public void UpdateMe()
        {
            
        }

        public void DisposeMe()
        {
            this._eventHelper.RaiseEvent(this, CustomerRowUserControlDisposeEventRaised, EventArgs.Empty);
        }

        #endregion

        #region HELPERS

        private void BtnDetailsOnClicked(object sender, System.EventArgs e)
        {
            // these heights ar not mandatory ...
            // just for test purposes
            this.Height = this.Height < 60 ? 65 : 32;
        }

        private void BtnEditOnClicked(object sender, System.EventArgs e)
        {
            if (sender is not Button btn) return;

            this._eventHelper.RaiseEvent(
                this, 
                CustomerRowUserControlEditEventRaised, 
                new ButtonIdEventArgs((int)btn.Tag));
        }

        private void BtnDeleteOnClicked(object sender, System.EventArgs e)
        {
            if (sender is not Button btn) return;

            this._eventHelper.RaiseEvent(
                this, 
                CustomerRowUserControlDeleteEventRaised,
                new ButtonIdEventArgs((int)btn.Tag));
        }

        private void RefreshLayout()
        {
            this.btnEdit.Tag = this.DataContext.Id;
            this.btnDelete.Tag = this.DataContext.Id;
            this.lblAge.Text = this._dataContext.Age.ToString();
            this.lblEmail.Text = this._dataContext.Email;
            this.lblName.Text = $@"{this._dataContext.FirstName} {this._dataContext.LastName}";
            this.lblPhone.Text = this._dataContext.Phone;
        }

        #endregion
    }
}
