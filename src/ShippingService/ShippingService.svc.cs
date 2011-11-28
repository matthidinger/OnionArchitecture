using System.Collections.Generic;
using Core.Domain;

namespace ShippingServices
{
    public class ShippingService : IShippingService
    {
        public string Ship(Product product)
        {
            return string.Format("Done Shipping: {0}", product.Name);
        }
    }
}


