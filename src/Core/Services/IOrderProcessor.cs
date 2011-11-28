using Core.Domain;

namespace Core.Services
{
    public interface IOrderProcessor
    {
        bool IsCreditCardValid(CreditCard creditCard);
    }
}