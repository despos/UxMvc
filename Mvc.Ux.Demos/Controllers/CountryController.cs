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
    public class CountryController : Controller
    {
        private readonly CountryService _service = new CountryService();
        
        public ActionResult Details(
            [Bind(Prefix = "id")] string code)
        {
            return Json(_service.GetCountryViewModel(code), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Find([Bind(Prefix = "id")] string code)
        {
            return Json(_service.GetCountryViewModelForEdit(code), JsonRequestBehavior.AllowGet);
        }
    }
}