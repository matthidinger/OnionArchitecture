using Infrastructure.ExternalServices.ContosoInventoryService;

namespace Infrastructure.Services
{
    internal class ContosoInventoryServiceAdapter : Core.Services.IInventoryService
    {
        private readonly ContosoInventoryServiceClient _client;

        public ContosoInventoryServiceAdapter()
        {
            _client = new ContosoInventoryServiceClient();    
        }

        public bool IsInStock(int productId)
        {
            return _client.InStock(productId);
        }
    }
}