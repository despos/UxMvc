///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Expoware.Youbiquitous.Mvc.Results;
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

        public ActionResult More(string view, int from, int howMany = 10)
        {
            var model = _service.GetCountryListViewModel();
            return PartialView(view, model.Countries.Skip(from).Take(howMany).ToList());
        }

        public ActionResult Page(
            [Bind(Prefix = "p")] int pageIndex = 1,
            [Bind(Prefix = "s")] int pageSize = 10)
        {
            var model = _service.GetPagedCountryListViewModel(pageIndex, pageSize);

            var result = new MultipleActionResult(
                PartialView("pv_country_grid", model),
                PartialView("pv_country_grid_pager", model));
            return result;
        }
    }
}