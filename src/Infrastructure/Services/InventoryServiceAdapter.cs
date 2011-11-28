using Infrastructure.WebServices.InventoryServices;

namespace Infrastructure.Services
{
    internal class InventoryServiceAdapter : Core.Services.IInventoryService
    {
        private readonly InventoryServiceClient _client;

        public InventoryServiceAdapter()
        {
            _client = new InventoryServiceClient();    
        }

        public bool IsInStock(int productId)
        {
            return _client.InStock(productId);
        }
    }
}