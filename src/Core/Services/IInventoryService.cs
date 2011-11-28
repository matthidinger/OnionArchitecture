namespace Core.Services
{
    public interface IInventoryService
    {
        bool IsInStock(int productId);
    }
}