using Core.Domain;

namespace Core.Services
{
    public interface IShippingService
    {
        string Ship(Product product);

    }
}