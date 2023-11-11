using System.Web.Mvc;
using Demo.Asp.Presenter.Contracts;
using Demo.Asp.UI.Base;
using Demo.Dependencies.Contracts;

namespace Demo.Asp.UI
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerPresenter _customerPresenter;

        public CustomerController(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._customerPresenter = dependencyContainer.Resolve<ICustomerPresenter>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(this._customerPresenter.GetAll());
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
