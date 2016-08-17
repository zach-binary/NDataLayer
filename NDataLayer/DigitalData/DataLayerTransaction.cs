using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace NDataLayer.DigitalData
{
    public class DataLayerTransaction : DataLayerObject
    {
        public DataLayerTransaction()
        {
            Profile = new Profile() { ProfileInfo = new ProfileInfo() };
            Total = new CartPrice();
            Items = new List<CartItem>();
        }

        public string TransactionID { get; set; }
        public Profile Profile { get; set; }
        public CartPrice Total { get; set; }

        [JsonProperty("item")]
        public List<CartItem> Items { get; set; }

        public bool ShouldSerializeItems()
        {
            return Items.Any();
        }

        public bool ShouldSerializeProfile()
        {
            return Profile.ShouldSerialize();
        }

        public bool ShouldSerializeTotal()
        {
            return Total.ShouldSerialize();
        }
    }
}
