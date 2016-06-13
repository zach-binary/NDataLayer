using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class DataLayerPage : DataLayerObject
    {
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public PageInfo()
        {
            BreadCrumbs = new List<string>();
        }

        public string PageID { get; set; }
        public string PageName { get; set; }
        public string DestinationURL { get; set; }
        public string ReferringURL { get; set; }
        public string SysEnv { get; set; }
        public string Variant { get; set; }
        public string Version { get; set; }
        public List<string> BreadCrumbs { get; set; }
        public string Author { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string Language { get; set; }
        public string GeoRegion { get; set; }
        public string IndustryCodes { get; set; }
        public string Publisher { get; set; }

        public bool ShouldSerializeBreadCrumbs()
        {
            return BreadCrumbs.Any();
        }
    }
}
