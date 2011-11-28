using Core.Domain;
using Infrastructure.WebServices.ShippingServices;

namespace Infrastructure.Services
{
    internal class  ShippingServiceAdapter : Core.Services.IShippingService
    {
        private readonly ShippingServiceClient _serviceClient;

        public ShippingServiceAdapter()
        {
            _serviceClient = new ShippingServiceClient();
        }

        public string Ship(Product product)
        {
            return _serviceClient.Ship(product);
        }
    }
}