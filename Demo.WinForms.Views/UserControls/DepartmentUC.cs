using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.WinForms.Views.Contracts.UserControls;

namespace Demo.WinForms.Views.UserControls
{
    // ReSharper disable once InconsistentNaming
    public partial class DepartmentUC : UserControl, IDepartmentUC
    {
        #region FIELDS

        private const int FlowControlHeight = 356;
        private readonly IEventHelper _eventHelper;

        #endregion

        #region PROPERTIES

        public IList<IDepartmentRowUC> DataContext { get; set; }

        #endregion

        #region EVENTS

        public event EventHandler DepartmentUserControlNewAddedEventRaised;
        public event EventHandler UserControlReachedCriticalHeight;

        #endregion

        #region C-TOR

        public DepartmentUC(IEventHelper eventHelper)
        {
            this._eventHelper = eventHelper;

            InitializeComponent();
        }

        #endregion

        #region METHODS

        public void UpdateMe()
        {
            this.flowLayoutPanel.Controls.Clear();

            foreach (var departmentRowUc in this.DataContext.ToList())
            {
                this.flowLayoutPanel.Controls.Add(departmentRowUc as UserControl);
            }

            if (this.flowLayoutPanel.DisplayRectangle.Size.Height > FlowControlHeight)
            {
                this._eventHelper.RaiseEvent(
                    this,
                    UserControlReachedCriticalHeight,
                    new ResizeWindowEventArgs { ResizeType = ResizeType.Grow });
            }
            else if (this.flowLayoutPanel.DisplayRectangle.Size.Height <= FlowControlHeight)
            {
                this._eventHelper.RaiseEvent(
                    this,
                    UserControlReachedCriticalHeight,
                    new ResizeWindowEventArgs { ResizeType = ResizeType.Shrink });
            }
        }

        #endregion

        #region HELPERS

        private void OnLoad(object sender, System.EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.UpdateMe();
        }

        private void BtnAddClicked(object sender, EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, DepartmentUserControlNewAddedEventRaised, e);
        }

        #endregion
    }
}
