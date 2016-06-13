using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class DataLayerEvent : DataLayerObject
    {
        public DataLayerEvent()
        {
            EventInfo = new EventInfo();
        }

        public EventInfo EventInfo { get; set; }
    }

    public class EventInfo
    {
        public string EventName { get; set; }
        public string EventAction { get; set; }
        public int? EventPoints { get; set; }
        public string Type { get; set; }
        public object TimeStamp { get; set; }
        public string Effect { get; set; }
    }
}
