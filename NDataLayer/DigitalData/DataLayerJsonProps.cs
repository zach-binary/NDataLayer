using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDataLayer.DigitalData
{
    public partial class DataLayer
    {
        // leverages json.net convention to hide properties
        public bool ShouldSerializeProducts()
        {
            return Products.Any();
        }

        public bool ShouldSerializeEvents()
        {
            return Events.Any();
        }

        public bool ShouldSerializeComponents()
        {
            return Components.Any();
        }

        public bool ShouldSerializeUsers()
        {
            return Users.Any();
        }

        public bool ShouldSerializeCart()
        {
            return Cart.ShouldSerializeAttributes() ||
                !string.IsNullOrEmpty(Cart.CartID) ||
                Cart.ShouldSerializeCategory() ||
                Cart.ShouldSerializeItems() ||
                Cart.Price.ShouldSerialize();
        }

        public bool ShouldSerializeTransaction()
        {
            return Transaction.ShouldSerializeAttributes() ||
                Transaction.ShouldSerializeCategory() ||
                Transaction.ShouldSerializeItems() ||
                Transaction.ShouldSerializeTotal() ||
                Transaction.ShouldSerializeProfile();
        }

        public bool ShouldSerializePrivacy()
        {
            return Privacy.ShouldSerializeCategories();
        }
    }
}
