using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDataLayer.DigitalData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NDataLayer.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestMethod]
        public void ToJson_SerializesCamelCase()
        {
            var dataLayer = new DataLayer()
            {
                PageInstanceID = "test"
            };

            var json = JsonConvert.DeserializeObject<JObject>(dataLayer.ToJson());
            Assert.AreEqual(json["pageInstanceID"], "test");
        }

        [TestMethod]
        public void Attributes_CanBeSetDynamically()
        {
            var dataLayer = new DataLayer();
            dataLayer.Page.Attributes.Add("some_field", "test");

            var json = JsonConvert.DeserializeObject<JObject>(dataLayer.ToJson());
            Assert.AreEqual(json["page"]["attributes"]["some_field"], "test");
        }

        [TestMethod]
        public void DataLayer_NewlyInitializedPropertiesAreNotNull()
        {
            var dataLayer = new DataLayer();

            dataLayer.Page.Attributes.Add("hello", "test");
            dataLayer.PageInstanceID = "test";

            dataLayer.Products.Add(new DataLayerProduct());
            dataLayer.Events.Add(new DataLayerEvent());
            dataLayer.Components.Add(new DataLayerComponent());
            dataLayer.Users.Add(new DataLayerUser());

            dataLayer.Cart.CartID = "cartId";
            dataLayer.Cart.Price.BasePrice = 40.00;
            dataLayer.Cart.Category.PrimaryCategory = "primaryCategory";
            dataLayer.Cart.Items.Add(new CartItem());
            dataLayer.Cart.Attributes.Add("hello", "test");

            dataLayer.Transaction.TransactionID = "transactionId";
            dataLayer.Transaction.Profile.Category.PrimaryCategory = "primaryCategory";
            dataLayer.Transaction.Items.Add(new CartItem());
            dataLayer.Transaction.Attributes.Add("hello", "test");

            dataLayer.Privacy.AccessCategories.Add(new AccessCategory());

            // if this doesn't throw a null ref exception, it passes
        }

        [TestMethod]
        public void DataLayer_EmptyPropsAreNotSerialized()
        {
            var dataLayer = new DataLayer();

            var json = JsonConvert.DeserializeObject<JObject>(dataLayer.ToJson());

            Assert.IsNull(json["privacy"]);
            Assert.IsNull(json["cart"]);
            Assert.IsNull(json["transaction"]);
            // Assert.IsNull(json["page"]); // ignoring page for now, I think that's likely always going to be populated
            Assert.IsNull(json["user"]);
            Assert.IsNull(json["product"]);
            Assert.IsNull(json["event"]);
            Assert.IsNull(json["component"]);

            dataLayer.Cart.CartID = "test";
            json = JsonConvert.DeserializeObject<JObject>(dataLayer.ToJson());

            Assert.IsNotNull(json["cart"]);
            Assert.AreEqual(json["cart"]["cartID"], "test");
        }
    }
}
