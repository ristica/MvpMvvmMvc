using System;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.WinForms.Views.Contracts.UserControls;

namespace Demo.WinForms.Views.UserControls
{
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class DepartmentRowUC : UserControl, IDepartmentRowUC
    {
        #region FIELDS

        private readonly IEventHelper _eventHelper;
        private IDepartmentModel _dataContext;

        #endregion

        #region PROPERTIES

        public IDepartmentModel DataContext
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

        public event EventHandler DepartmentRowUserControlEditEventRaised;
        public event EventHandler DepartmentRowUserControlDeleteEventRaised;
        public event EventHandler DepartmentRowUserControlDisposeEventRaised;

        #endregion

        #region C-TOR

        public DepartmentRowUC(IEventHelper eventHelper)
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
            this._eventHelper.RaiseEvent(this, DepartmentRowUserControlDisposeEventRaised, null);
        }

        #endregion

        #region HELPERS

        private void BtnDetailsOnClicked(object sender, System.EventArgs e)
        {

        }

        private void BtnEditOnClicked(object sender, System.EventArgs e)
        {
            if (sender is not Button btn) return;

            this._eventHelper.RaiseEvent(
                this, 
                DepartmentRowUserControlEditEventRaised,
                new ButtonIdEventArgs((int)btn.Tag));
        }

        private void BtnDeleteOnClicked(object sender, System.EventArgs e)
        {
            if (sender is not Button btn) return;

            this._eventHelper.RaiseEvent(
                this, 
                DepartmentRowUserControlDeleteEventRaised,
                new ButtonIdEventArgs((int)btn.Tag));
        }

        private void RefreshLayout()
        {
            this.btnEdit.Tag = this.DataContext.Id;
            this.btnDelete.Tag = this.DataContext.Id;
            this.lblName.Text = this.DataContext.Name;
        }

        #endregion
    }
}
