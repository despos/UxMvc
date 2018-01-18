///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
// M01 - Picking Items from a (Long) List
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System.Web.Mvc;
using Mvc.Ux.Demos.Application;

namespace Mvc.Ux.Demos.Controllers
{
    public class DemoController : Controller
    {
        private readonly DemoService _service = new DemoService();

        public ActionResult Picking()
        {
            var model = _service.GetCountryListViewModel();
            return View(model);
        }
    }
}