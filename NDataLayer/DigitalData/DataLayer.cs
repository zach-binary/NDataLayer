using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class DataLayer
    {
        public DataLayer()
        {
            Page = new Page() { PageInfo = new PageInfo() };
            Products = new List<Product>();
            Events = new List<Event>();
            Components = new List<Component>();
            Cart = new Cart();
            Transaction = new Transaction();
            Privacy = new Privacy();
            Users = new List<User>();
        }

        public string PageInstanceID { get; set; }
        public Page Page { get; set; }

        [JsonProperty("product")]
        public List<Product> Products { get; set; }

        public Cart Cart { get; set; }
        public Transaction Transaction { get; set; }

        [JsonProperty("event")]
        public List<Event> Events { get; set; }

        [JsonProperty("component")]
        public List<Component> Components { get; set; }

        [JsonProperty("user")]
        public List<User> Users { get; set; }

        public Privacy Privacy { get; set; }

        public string Version = "1.0";

        public Dictionary<string, object> Attributes { get; set; }

        public bool ShouldSerializeProducts()
        {
            return Products.Any();
        }

        public string ToJson(bool pretty = false)
        {
            return JsonConvert.SerializeObject(this,
                pretty ? Formatting.Indented : Formatting.None,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        public string ToScript(bool pretty = false)
        {
            return string.Format(@"<script>var digitalData = {0};</script>", ToJson(pretty));
        }
    }

    public class Category
    {
        public string PrimaryCategory { get; set; }
    }

    public abstract class DataLayerObject
    {
        public DataLayerObject()
        {
            Category = new Category();
            Attributes = new Dictionary<string, object>();
        }

        public Category Category { get; set; }
        public Dictionary<string, object> Attributes { get; set; }


        public bool ShouldSerializeCategory()
        {
            return !string.IsNullOrEmpty(Category.PrimaryCategory);
        }

        public bool ShouldSerializeAttributes()
        {
            return Attributes.Any();
        }
    }

}
