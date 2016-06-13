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
    public partial class DataLayer
    {
        public DataLayer()
        {
            Page = new DataLayerPage() { PageInfo = new PageInfo() };
            Products = new List<DataLayerProduct>();
            Events = new List<DataLayerEvent>();
            Components = new List<DataLayerComponent>();
            Cart = new DataLayerCart();
            Transaction = new DataLayerTransaction();
            Privacy = new DataLayerPrivacy();
            Users = new List<DataLayerUser>();
        }

        public string PageInstanceID { get; set; }
        public DataLayerPage Page { get; set; }

        [JsonProperty("product")]
        public List<DataLayerProduct> Products { get; set; }

        public DataLayerCart Cart { get; set; }
        public DataLayerTransaction Transaction { get; set; }

        [JsonProperty("event")]
        public List<DataLayerEvent> Events { get; set; }

        [JsonProperty("component")]
        public List<DataLayerComponent> Components { get; set; }

        [JsonProperty("user")]
        public List<DataLayerUser> Users { get; set; }

        public DataLayerPrivacy Privacy { get; set; }

        public string Version = "1.0";

        public Dictionary<string, object> Attributes { get; set; }

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
