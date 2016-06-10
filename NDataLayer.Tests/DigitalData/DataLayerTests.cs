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

            dataLayer.Products.Add(new Product());
            dataLayer.Events.Add(new Event());
            dataLayer.Components.Add(new Component());
            dataLayer.Users.Add(new User());

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
    }
}
