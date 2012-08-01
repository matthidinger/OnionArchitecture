using Infrastructure.ExternalServices.AcmeShippingService;

namespace Infrastructure.Services
{
    internal class AcmeShippingServiceAdapter : Core.Services.IShippingService
    {
        private readonly AcmeShippingServiceClient _serviceClient;

        public AcmeShippingServiceAdapter()
        {
            _serviceClient = new AcmeShippingServiceClient();
        }

        public string Ship(int productId)
        {
            return _serviceClient.Ship(productId);
        }
    }
}