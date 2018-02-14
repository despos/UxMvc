///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Web.Mvc;
using Expoware.Youbiquitous.Extensions;
using Expoware.Youbiquitous.Mvc.Extensions;
using Expoware.Youbiquitous.Mvc.Results;
using Mvc.Ux.Demos.Application;
using Mvc.Ux.Demos.Common;
using Mvc.Ux.Demos.Models;
using Mvc.Ux.Demos.Models.Demo;

namespace Mvc.Ux.Demos.Controllers
{
    public class DemoController : Controller
    {
        private readonly DemoService _service = new DemoService();
        private readonly CountryService _countryService = new CountryService();

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

        /// <summary>
        /// MODULE 10: Better tables
        /// </summary>
        /// <returns></returns>
        public ActionResult Tables()
        {
            var model = _countryService.GetCountryListViewModel();
            return View(model);
        }

        /// <summary>
        /// MODULE 11: Paging
        /// </summary>
        /// <returns></returns>
        public ActionResult Paging()
        {
            var model = new PagedCountryListViewModel { Header = new HeaderViewModel(246) };
            return View(model);
        }

        /// <summary>
        /// MODULE 12: Feedback
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Feedback")]
        public ActionResult FeedbackGet(SignupViewModel input)
        {
            if (input == null)
                input = new SignupViewModel();
            return View(input);
        }
        [HttpPost]
        [ActionName("Feedback")]
        public ActionResult FeedbackPost(SignupViewModel input)
        {
            if (input == null)
                return Json(CommandResponse.Fail.SetMessage("Invalid input"));
            if (input.Name.IsNullOrWhitespace())
                return Json(CommandResponse.Fail.SetMessage("Name is missing"));

            var outcome = (DateTime.Now.Second % 2) > 0 
                ? CommandResponse.Ok.SetMessage("Welcome to the team!")
                : CommandResponse.Fail.SetMessage("Oops! Something went unexpectedly wrong.");

            return Json(outcome);
        }

        /// <summary>
        /// MODULE 13: Printing
        /// </summary>
        /// <returns></returns>
        public ActionResult Printing(string t = "")
        {
            var model = _countryService.GetCountryListViewModel();
            var view = t == "printer" ? "print_printer" : "print_html";
            return View(view, model);
        }

        public ActionResult Pdf(string id)
        {
            var country = _countryService.GetCountryViewModel(id);
            var htmlString = this.RenderPartialViewToString("pv_country_print_template", country);

            var fullFileName = "";
            try
            {
                if (Request.Url != null)
                {
                    var fileName = UrlHelper.GenerateContentUrl(
                        $"~/content/assets/{country.CountryCode}.pdf", HttpContext);
                    fullFileName = Server.MapPath(fileName);

                    var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                    PdfService.Create(htmlString, fullFileName, baseUrl, country.CountryName);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return File(fullFileName, "application/pdf", country.CountryName + ".pdf");
        }
    }
}