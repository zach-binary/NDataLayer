using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public class DataLayerCart : DataLayerObject
    {
        public DataLayerCart() : base()
        {
            Price = new CartPrice();
            Items = new List<CartItem>();
        }

        public string CartID { get; set; }
        public CartPrice Price { get; set; }

        [JsonProperty("item")]
        public List<CartItem> Items { get; set; }

        public bool ShouldSerializeItems()
        {
            return Items.Any();
        }
    }

    public class CartPrice
    {
        public double? BasePrice { get; set; }
        public string VoucherCode { get; set; }
        public double? VoucherDiscount { get; set; }
        public string Currency { get; set; }
        public double? TaxRate { get; set; }
        public double? Shipping { get; set; }
        public string ShippingMethod { get; set; }
        public double? PriceWithTax { get; set; }
        public double? CartTotal { get; set; }

        public bool ShouldSerialize()
        {
            return BasePrice != null ||
                !string.IsNullOrEmpty(VoucherCode) ||
                VoucherDiscount != null ||
                !string.IsNullOrEmpty(Currency) ||
                TaxRate != null ||
                Shipping != null ||
                !string.IsNullOrEmpty(ShippingMethod) ||
                PriceWithTax != null ||
                CartTotal != null;
        }
    }

    public class CartItem : DataLayerObject
    {
        public CartItem() : base()
        {
            ProductInfo = new ProductInfo();
            LinkedProducts = new List<DataLayerProduct>();
        }

        public ProductInfo ProductInfo { get; set; }
        public int Quantity { get; set; }

        [JsonProperty("linkedProduct")]
        public List<DataLayerProduct> LinkedProducts { get; set; }

        public bool ShouldSerializeLinkedProducts()
        {
            return LinkedProducts.Any();
        }
    }
}
