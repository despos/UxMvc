///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
// M01 - Picking Items from a (Long) List
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Web.Mvc;
using Mvc.Ux.Demos.Application;
using Mvc.Ux.Demos.Models.Demo;

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

        [HttpGet]
        [ActionName("date")]
        public ActionResult DateForGet(DateTime? selectedDate)
        {
            var model = new DateViewModel();
            if (selectedDate.HasValue)
                model.TheDate = selectedDate;
            return View(model);
        }

        [HttpPost]
        [ActionName("date")]
        public ActionResult DateForPost(DateTime? selectedDate)
        {
            return RedirectToAction("Date", new {selectedDate = selectedDate });
        }
    }
}