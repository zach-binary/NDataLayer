using NDataLayer.DigitalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NDataLayer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataLayer = HttpContext.Items["dataLayer"] as DataLayer;
            dataLayer.PageInstanceID = "Home-TestSite";
            dataLayer.Page.PageInfo.PageName = "home page";

            return View();
        }

        public ActionResult DataLayerJson()
        {
            var dataLayer = HttpContext.Items["dataLayer"] as DataLayer;
            return Content(dataLayer.ToJson(true));
        }
    }
}