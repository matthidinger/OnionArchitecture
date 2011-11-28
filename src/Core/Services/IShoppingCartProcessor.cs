using Core.Domain;

namespace Core.Services
{
    public interface IShoppingCartProcessor
    {
        string CompleteCheckout(ShoppingCart cart, CreditCard creditCard);
    }
}