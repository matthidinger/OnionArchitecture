using Core.Domain;

namespace Infrastructure.Services
{
    internal class PayPalOrderProcessor : Core.Services.IOrderProcessor
    {
        private readonly ExternalServices.PayPalService.PayPalServiceClient _client;

        public PayPalOrderProcessor()
        {
            _client = new ExternalServices.PayPalService.PayPalServiceClient();
        }


        public bool IsCreditCardValid(CreditCard creditCard)
        {
            // Need to project our Domain CreditCard into a PayPal CreditCard

            var payPalCreditCard = new ExternalServices.PayPalService.CreditCard
                {
                    CardNumber = creditCard.Number,
                    CardExpiration = creditCard.Expiration
                };

            var validationResult = _client.ValidateCreditCard(payPalCreditCard);
            return validationResult == ExternalServices.PayPalService.CardValidationResult.Valid;
        }
    }
}