///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Web.Mvc;
using Expoware.Youbiquitous.Mvc.Results;
using Mvc.Ux.Demos.Application;
using Mvc.Ux.Demos.Models;
using Mvc.Ux.Demos.Models.Demo;

namespace Mvc.Ux.Demos.Controllers
{
    public class DemoController : Controller
    {
        private readonly DemoService _service = new DemoService();

        /// <summary>
        /// MODULE 2: Picking Items from a Long List
        /// </summary>
        /// <returns></returns>
        public ActionResult Picking()
        {
            var model = _service.GetCountryListViewModel();
            return View(model);
        }

        /// <summary>
        /// MODULE 3: Letting Users Enter a Date
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("date")]
        public ActionResult DateForGet(DateTime? selectedDate)
        {
            var model = new DateViewModel();
            if (selectedDate.HasValue)
                model.TheDate = selectedDate;
            return View(model);
        }

        /// <summary>
        /// MODULE 3: Letting Users Enter a Date
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("date")]
        public ActionResult DateForPost(DateTime? selectedDate)
        {
            return RedirectToAction("Date", new {selectedDate = selectedDate });
        }

        /// <summary>
        /// MODULE 4: Providing a Better Experience for Changing Passwords
        /// </summary>
        /// <returns></returns>
        public ActionResult Pswd()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        /// <summary>
        /// MODULE 5: Taking Care of Those That Bootstrap Left Behind
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("bsext")]
        public ActionResult BsExtForGet()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        /// <summary>
        /// MODULE 5: Taking Care of Those That Bootstrap Left Behind
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("bsext")]
        public ActionResult BsExtForPost(string yourSkills1, string yourSkills2)
        {
            return RedirectToAction("bsext");
        }

        /// <summary>
        /// MODULE 6: Being Tidy and Clean with Drop-down Content
        /// </summary>
        /// <returns></returns>
        public ActionResult Dropdown()
        {
            var model = _service.GetCustomerListViewModel();
            return View(model);
        }

        /// <summary>
        /// MODULE 6: Being Tidy and Clean with Drop-down Content
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("d")]
        public ActionResult DeleteCustomer(int id)
        {
            var model = _service.TryDeleteCustomer(id);

            // Return 
            var result = new MultipleActionResult(
                PartialView("pv_ListOfCustomers", model),
                PartialView("pv_OnBehalfOfCustomers", model));
            return result;
        }

        /// <summary>
        /// MODULE 7: What If It’s Truly Mobile?
        /// </summary>
        /// <returns></returns>
        public ActionResult Device()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        /// <summary>
        /// MODULE 8: Auto-adaptive Images
        /// </summary>
        /// <returns></returns>
        public ActionResult Img()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        /// <summary>
        /// MODULE 9: Large input forms
        /// </summary>
        /// <returns></returns>
        public ActionResult LgForm()
        {
            var model = new ViewModelBase();
            return View(model);
        }
    }
}