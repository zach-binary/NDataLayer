using NDataLayer.DigitalData;
using NDataLayer.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NDataLayer.Web.Controllers
{
    public class HomeController : Controller
    {
        private DataLayer _dataLayer;
        private ITestService _testService;

        public HomeController(DataLayer dataLayer, ITestService testService)
        {
            _dataLayer = dataLayer;
            _testService = testService;
        }

        public ActionResult Index()
        {
            _testService.DoSomething();

            _dataLayer.PageInstanceID = "Home-TestSite";
            _dataLayer.Page.PageInfo.PageName = "home page";

            return View();
        }

        public ActionResult DataLayerJson()
        {
            return Content(_dataLayer.ToScript(true));
        }
    }
}