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
            //_testService.DoSomething();

            _dataLayer.PageInstanceID = "Home-TestSite";
            _dataLayer.Page.PageInfo.PageName = "home page";
            DataLayerEvent dataEvent = new DataLayerEvent();

            dataEvent.EventInfo = new EventInfo();
            dataEvent.EventInfo.Effect = "effect1";
            dataEvent.EventInfo.EventAction = "addtocart";
            dataEvent.EventInfo.EventName = "click";
            dataEvent.EventInfo.EventPoints = 1;
            dataEvent.EventInfo.TimeStamp = DateTime.Now;
            dataEvent.EventInfo.Type = "eventType";

            dataEvent.Attributes.Add("productID", "123456");
            dataEvent.Attributes.Add("sku", "182839");
            _dataLayer.Events.Add(dataEvent);

            return View();
        }

        public ActionResult DataLayerJson()
        {
            return Content(_dataLayer.ToScript(true));
        }
    }
}