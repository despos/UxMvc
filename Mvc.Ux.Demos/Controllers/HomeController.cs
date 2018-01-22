///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System.Web.Mvc;
using Mvc.Ux.Demos.Models;

namespace Mvc.Ux.Demos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }
        public ActionResult Tech()
        {
            var model = new ViewModelBase();
            return View(model);
        }
    }
}