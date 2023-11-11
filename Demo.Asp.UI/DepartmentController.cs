using System.Web.Mvc;
using Demo.Asp.Presenter.Contracts;
using Demo.Asp.UI.Base;
using Demo.Dependencies.Contracts;

namespace Demo.Asp.UI
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentPresenter _departmentPresenter;

        public DepartmentController(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._departmentPresenter = dependencyContainer.Resolve<IDepartmentPresenter>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(this._departmentPresenter.GetAll());
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
