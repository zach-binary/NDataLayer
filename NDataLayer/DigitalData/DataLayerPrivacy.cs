using System.Collections.Generic;
using System.Linq;

namespace NDataLayer.DigitalData
{
    public class DataLayerPrivacy
    {
        public DataLayerPrivacy()
        {
            AccessCategories = new List<AccessCategory>();
        }

        public List<AccessCategory> AccessCategories { get; set; }

        public bool ShouldSerializeCategories()
        {
            return AccessCategories.Any();
        }
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
