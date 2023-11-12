using System;
using System.Collections.Generic;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Services.Contracts;
using Demo.WinForms.Presenters.Base;
using Demo.WinForms.Presenters.Contracts.UserControls;
using Demo.WinForms.Views.Contracts.Base;
using Demo.WinForms.Views.Contracts.UserControls;

namespace Demo.WinForms.Presenters.UserControls
{
    public class DepartmentViewPresenter : Presenter, IDepartmentViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly IDepartmentUC _uc;
        private readonly IDepartmentService<IDepartmentModel> _service;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        #endregion

        #region C-TOR

        public DepartmentViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();
            this._service = dependencyContainer.Resolve<IDepartmentService<IDepartmentModel>>();
            this._uc = dependencyContainer.Resolve<IDepartmentUC>();

            this.SubscribeToUserInterfaceEvents();
            this.SubscribeToNotifications();
            this.LoadDepartments();
        }

        #endregion

        #region METHODS

        public IBaseUserControl GetUserControl() => this._uc;

        public void Receive(object sender, EventArgs args, int messageId)
        {
            switch ((MessageType)messageId)
            {
                case MessageType.DepartmentDeletedMessage:
                    this._uc.DataContext.Clear();
                    this._uc.UpdateMe();
                    this.LoadDepartments();
                    this._uc.UpdateMe();
                    break;
            }
        }

        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._uc.DepartmentUserControlNewAddedEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._uc.UserControlReachedCriticalHeight -= (sender, args) => { };

            foreach (var rowUc in this._uc.DataContext)
            {
                rowUc.DisposeMe();
            }
        }

        #endregion

        #region HELPERS

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._uc.DepartmentUserControlNewAddedEventRaised += (sender, args) =>
            {
                // set data context
                // update view
            };

            this._uc.UserControlReachedCriticalHeight += (sender, args) =>
            {
                this._messageNotificationsHelper.Publish<EventArgs>(
                    this,
                    args,
                    (int)MessageType.ResizeMainWindowMessage);
            };
        }

        private void SubscribeToNotifications()
        {
            this._messageNotificationsHelper.Subscribe(this, (int)MessageType.DepartmentDeletedMessage);
        }

        private void LoadDepartments()
        {
            var departments = this._service.GetAll();
            var rows = new List<IDepartmentRowUC>();

            foreach (var d in departments)
            {
                var rowPresenter = DependencyContainer.Resolve<IDepartmentRowViewPresenter>();

                if (rowPresenter.GetUserControl() is IDepartmentRowUC departmentRow) departmentRow.DataContext = d;
                else continue;

                rows.Add(departmentRow);
            }

            this._uc.DataContext = rows;
        }

        #endregion
    }
}
