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
    }
}
