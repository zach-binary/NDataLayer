using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class DataLayerPrivacy
    {
        public DataLayerPrivacy()
        {
            AccessCategories = new List<AccessCategory>();
        }

        public List<AccessCategory> AccessCategories { get; set; }
    }

    public class AccessCategory
    {
        public AccessCategory()
        {
            Domains = new List<string>();
        }

        public string CategoryName { get; set; }
        public List<string> Domains { get; set; }
    }
}
