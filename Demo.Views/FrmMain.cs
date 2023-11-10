using System;
using System.Drawing;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Views.Contracts.Views;

namespace Demo.Views
{
    public partial class FrmMain : Form, IFrmMain
    {
        #region FIELDS

        private readonly IEventHelper _eventHelper;

        #endregion

        #region PROPERTIES

        public string WindowTitle { get; set; }

        #endregion

        #region EVENTS

        public event EventHandler FormLoadEventRaised;
        public event EventHandler FormCloseEventRaised;
        public event EventHandler HelpViewShowEventRaised;
        public event EventHandler CustomersViewShowEventRaised;
        public event EventHandler DepartmentsViewShowEventRaised;

        #endregion

        #region  C-TOR

        public FrmMain(IEventHelper eventHelper)
        {
            this._eventHelper = eventHelper;

            InitializeComponent();
        }

        #endregion

        #region METHODS

        public void ShowMe()
        {
            // intentionally left blank ...
        }

        public void ResizeMe(EventArgs args)
        {
            if (args is not ResizeWindowEventArgs) return;

            if (((ResizeWindowEventArgs)args).ResizeType == ResizeType.Grow)
            {
                this.Width = 837;
            }
            else if (((ResizeWindowEventArgs)args).ResizeType == ResizeType.Shrink)
            {
                this.Width = 819;
            }
        }

        public Panel GetContentPanel()
        {
            return this.pnlContent;
        }

        #endregion

        #region HELPERS

        private void PictureBoxInfoOnClicked(object sender, System.EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, HelpViewShowEventRaised, e);
        }

        private void BtnCustomersOnClicked(object sender, EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, CustomersViewShowEventRaised, e);
            this.SetButtonFocusStyle(ButtonEnum.Customer);
        }

        private void BtnDepartmentsOnClicked(object sender, EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, DepartmentsViewShowEventRaised, e);
            this.SetButtonFocusStyle(ButtonEnum.Department);
        }

        private void FrmMainOnLoad(object sender, EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, FormLoadEventRaised, e);
            this.SetButtonFocusStyle(ButtonEnum.Customer);
        }

        private void FrmMainOnClosing(object sender, FormClosingEventArgs e)
        {
            this._eventHelper.RaiseEvent(this, FormCloseEventRaised, e);
        }

        private void SetButtonFocusStyle(ButtonEnum buttonEnum)
        {
            switch (buttonEnum)
            {
                case ButtonEnum.Customer:
                    this.btnCustomers.BackColor = Color.Silver;
                    this.btnDepartments.BackColor = Color.White;
                    break;
                case ButtonEnum.Department:
                    this.btnCustomers.BackColor = Color.White;
                    this.btnDepartments.BackColor = Color.Silver;
                    break;
            }
        }

        private enum ButtonEnum
        {
            Customer,
            Department
        }

        #endregion

        #region RESIZE WIN32

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x84: //WM_NCHITTEST
                    var result = (HitTest)m.Result.ToInt32();
                    if (result == HitTest.Top || result == HitTest.Bottom)
                        m.Result = new IntPtr((int)HitTest.Caption);
                    if (result == HitTest.TopLeft || result == HitTest.BottomLeft)
                        m.Result = new IntPtr((int)HitTest.Left);
                    if (result == HitTest.TopRight || result == HitTest.BottomRight)
                        m.Result = new IntPtr((int)HitTest.Right);

                    break;
            }
        }
        enum HitTest
        {
            Caption = 2,
            Transparent = -1,
            Nowhere = 0,
            Client = 1,
            Left = 10,
            Right = 11,
            Top = 12,
            TopLeft = 13,
            TopRight = 14,
            Bottom = 15,
            BottomLeft = 16,
            BottomRight = 17,
            Border = 18
        }

        #endregion
    }
}
