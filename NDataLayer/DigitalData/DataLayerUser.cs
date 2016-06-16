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

        public bool ShouldSerializeSegment()
        {
            return Segment.Any();
        }

        public bool ShouldSerializeProfiles()
        {
            return Profiles.Any();
        }
    }

    public class Profile : DataLayerObject
    {
        public Profile()
        {
            ProfileInfo = new ProfileInfo();
            Address = new Address();
            ShippingAddress = new Address();
            Social = new Social();
        }

        public ProfileInfo ProfileInfo { get; set; }
        public Address Address { get; set; }
        public Address ShippingAddress { get; set; }
        public Social Social { get; set; }

        public bool ShouldSerialize()
        {
            return ProfileInfo.ShouldSerialize() ||
                Address.ShouldSerialize() ||
                ShippingAddress.ShouldSerialize() ||
                Social.ShouldSerialize();
        }
    }

    public class ProfileInfo
    {
        public string ProfileID { get; set; }
        public string UserName { get; set; }

        public bool ShouldSerialize()
        {
            return this.GetType().GetProperties()
                .Where(pi => pi.GetValue(this) is string)
                .Select(pi => (string)pi.GetValue(this))
                .Any(value => !String.IsNullOrEmpty(value));
        }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public bool ShouldSerialize()
        {
            return this.GetType().GetProperties()
                .Where(pi => pi.GetValue(this) is string)
                .Select(pi => (string)pi.GetValue(this))
                .Any(value => !String.IsNullOrEmpty(value));
        }
    }

    public class Social
    {
        public string Twitter { get; set; }
        public string TwitterInfo { get; set; }
        public string Facebook { get; set; }
        public string FacebookInfo { get; set; }

        public bool ShouldSerialize()
        {
            return this.GetType().GetProperties()
                .Where(pi => pi.GetValue(this) is string)
                .Select(pi => (string)pi.GetValue(this))
                .Any(value => !String.IsNullOrEmpty(value));
        }
    }
}
