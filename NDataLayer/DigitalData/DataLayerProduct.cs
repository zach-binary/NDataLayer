using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class DataLayerProduct : DataLayerObject
    {
        public DataLayerProduct() : base()
        {
            LinkedProducts = new List<DataLayerProduct>();
        }

        public ProductInfo ProductInfo { get; set; }

        [JsonProperty("linkedProduct")]
        public List<DataLayerProduct> LinkedProducts { get; set; }

        public bool ShouldSerializeLinkedProducts()
        {
            return LinkedProducts.Any();
        }
    }

    public class ProductInfo
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductURL { get; set; }
        public string ProductImage { get; set; }
        public string ProductThumbnail { get; set; }
        public string Manufacturer { get; set; }
        public string Size { get; set; }
    }
}
