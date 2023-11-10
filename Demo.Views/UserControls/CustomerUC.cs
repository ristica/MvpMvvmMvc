using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Views.Contracts.UserControls;

namespace Demo.Views.UserControls
{
    // ReSharper disable once InconsistentNaming
    public partial class CustomerUC : UserControl, ICustomerUC
    {
        #region FIELDS

        private const int FlowControlHeight = 356;
        private readonly IEventHelper _eventHelper;

        #endregion

        #region PROPERTIES

        public IList<ICustomerRowUC> DataContext { get; set; }

        #endregion

        #region EVENTS

        public event EventHandler CustomerUserControlNewAddedEventRaised;
        public event EventHandler UserControlReachedCriticalHeight;

        #endregion

        #region C-TOR

        public CustomerUC(IEventHelper eventHelper)
        {
            this._eventHelper = eventHelper;

            InitializeComponent();
        }

        #endregion

        #region METHODS

        public void UpdateMe()
        {
            this.flowLayoutPanel.Controls.Clear();

            foreach (var customerRowUc in this.DataContext.ToList())
            {
                this.flowLayoutPanel.Controls.Add(customerRowUc as UserControl);
            }

            switch (this.flowLayoutPanel.DisplayRectangle.Size.Height)
            {
                case > FlowControlHeight:
                    this._eventHelper.RaiseEvent(
                        this, 
                        UserControlReachedCriticalHeight, 
                        new ResizeWindowEventArgs { ResizeType = ResizeType.Grow });
                    break;
                case <= FlowControlHeight:
                    this._eventHelper.RaiseEvent(
                        this,
                        UserControlReachedCriticalHeight,
                        new ResizeWindowEventArgs { ResizeType = ResizeType.Shrink });
                    break;
            }
        }

        #endregion

        #region HELPERS

        private void OnLoad(object sender, System.EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.UpdateMe();
        }

        private void BtnAddClicked(object sender, System.EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, CustomerUserControlNewAddedEventRaised, e);
        }

        #endregion
    }
}
