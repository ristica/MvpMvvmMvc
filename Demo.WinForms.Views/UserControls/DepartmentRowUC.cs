using System;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.WinForms.Views.Contracts.UserControls;

namespace Demo.WinForms.Views.UserControls
{
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once InconsistentNaming
    public partial class DepartmentRowUC : UserControl, IDepartmentRowUC
    {
        private readonly IEventHelper _eventHelper;

        public event EventHandler DepartmentRowUserControlEditEventRaised;
        public event EventHandler DepartmentRowUserControlDeleteEventRaised;
        public event EventHandler DepartmentRowUserControlDisposeEventRaised;

        public DepartmentRowUC(IEventHelper eventHelper)
        {
            this._eventHelper = eventHelper;

            InitializeComponent();
        }

        public void UpdateMe()
        {
            
        }

        private void BtnDetailsOnClicked(object sender, System.EventArgs e)
        {
            // these heights ar not mandatory ...
            // just for test purposes
            this.Height = this.Height < 60 ? 65 : 32;
        }

        private void BtnEditOnClicked(object sender, System.EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, DepartmentRowUserControlEditEventRaised, e);
        }

        private void BtnDeleteOnClicked(object sender, System.EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, DepartmentRowUserControlDeleteEventRaised, e);
        }
        public void DisposeMe()
        {
            this._eventHelper.RaiseEvent(this, DepartmentRowUserControlDisposeEventRaised, null);
        }
    }
}
