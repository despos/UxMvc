///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc.Ux.Demos.Models.Demo;

namespace Mvc.Ux.Demos.Controllers
{
    public class AppController : Controller
    {
        /// <summary>
        /// Generic error page to show in case of unhandled exceptions
        /// </summary>
        /// <returns>HTML</returns>
        public ActionResult Error(Exception exception)
        {
            var code = GetStatusCode(exception);
            Response.TrySkipIisCustomErrors = true;

            var message = string.Format("500 error");
            if (code == 404)
            {
                message = "404 error";
            }
            if (code == 500)
            {
                message = exception.Message;
            }

            var model = new ErrorViewModel {ErrorOccurred = message};
            return View(model);
        }


        #region PRIVATE
        private static int GetStatusCode(Exception exception)
        {
            var httpException = exception as HttpException;
            if (httpException == null)
                return (int) HttpStatusCode.InternalServerError;
            return httpException.GetHttpCode();
        }
        #endregion
    }
}