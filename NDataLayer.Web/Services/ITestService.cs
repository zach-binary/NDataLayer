using NDataLayer.DigitalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NDataLayer.Web.Services
{
    public interface ITestService
    {
        void DoSomething();
    }

    public class TestService : ITestService
    {
        private DataLayer _dataLayer;

        public TestService(DataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public void DoSomething()
        {
            _dataLayer.Events.Add(new DataLayerEvent()
            {
                EventInfo = new EventInfo()
                {
                    EventName = "Test Service Called"
                }
            });
        }
    }
}