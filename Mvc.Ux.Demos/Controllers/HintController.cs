///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
// M01 - Picking Items from a (Long) List
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Linq;
using System.Web.Mvc;
using Mvc.Ux.Demos.Backend.Persistence;
using Mvc.Ux.Demos.Common;

namespace Mvc.Ux.Demos.Controllers
{
    public class HintController : Controller
    {
        public JsonResult Countries(string filter = "")
        {
            var repository = new CountryRepository();
            var list = (from country in repository.AllBy(filter)
                        select new AutoCompleteItem()
                        {
                            id = country.CountryCode,
                            value = country.CountryName
                        }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Countries2(string filter = "")
        {
            var all = new CountryRepository().All();
            var list = (from country in all
                let match = String.Format("{0} {1} {2} {3}",
                    country.CountryCode, country.CountryName, country.ContinentName, country.CurrencyCode).ToLower()
                where match.Contains(filter)
                select new AutoCompleteItem()
                {
                    id = country.CountryCode,
                    value = country.CountryName
                }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}