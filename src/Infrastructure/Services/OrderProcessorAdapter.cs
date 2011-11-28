using Core.Domain;
using Infrastructure.WebServices.OrderProcessorServices;

namespace Infrastructure.Services
{
    internal class OrderProcessorAdapter : Core.Services.IOrderProcessor
    {
        private readonly OrderProcessorServiceClient _client;

        public OrderProcessorAdapter()
        {
            _client = new OrderProcessorServiceClient();
        }

        public bool IsCreditCardValid(CreditCard creditCard)
        {
            return _client.IsCreditCardValid(creditCard.Number);
        }
    }
}