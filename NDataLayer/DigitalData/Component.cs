using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class Component : DataLayerObject
    {
        public ComponentInfo ComponentInfo { get; set; }
    }

    public class ComponentInfo
    {
        public string ComponentID { get; set; }
        public string ComponentName { get; set; }
        public string Description { get; set; }
    }
}
