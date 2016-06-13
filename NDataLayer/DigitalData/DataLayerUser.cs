using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class DataLayerUser
    {
        public DataLayerUser()
        {
            Segment = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Segment { get; set; }

        [JsonProperty("profile")]
        public List<Profile> Profiles { get; set; }
    }

    public class Profile : DataLayerObject
    {
        public ProfileInfo ProfileInfo { get; set; }
        public Address Address { get; set; }
        public Address ShippingAddress { get; set; }
        public Social Social { get; set; }
    }

    public class ProfileInfo
    {
        public string ProfileID { get; set; }
        public string UserName { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class Social
    {
        public string Twitter { get; set; }
        public string TwitterInfo { get; set; }
        public string Facebook { get; set; }
        public string FacebookInfo { get; set; }
    }
}
