using System.Collections.Generic;
using System.ServiceModel;

namespace PayPalServices
{
    [ServiceContract]
    public class PayPalService
    {
        public static Dictionary<string, CardValidationResult> KnownCreditCards = new Dictionary<string, CardValidationResult>
            {
                {"1111", CardValidationResult.Valid},
                {"2222", CardValidationResult.Expired},
                {"3333", CardValidationResult.MissingCvv2Code},
                {"4444",  CardValidationResult.InvalidCardNumber},
            };

        [OperationContract]
        public CardValidationResult ValidateCreditCard(CreditCard card)
        {
            if (KnownCreditCards.ContainsKey(card.CardNumber))
            {
                return KnownCreditCards[card.CardNumber];
            }

            return CardValidationResult.InvalidCardNumber;
        }

        [OperationContract]
        public bool VerifyAvailableFunds(CreditCard card, decimal amount)
        {
            return true;
        }

        [OperationContract]
        public bool ChargeAccount(CreditCard card, decimal amount)
        {
            return true;
        }

        [OperationContract]
        public bool SubmitFraudRequest(CreditCard card)
        {
            return true;
        }

        [OperationContract]
        public bool IsCardHighRisk(CreditCard card)
        {
            return true;
        }

        [OperationContract]
        public bool BillToAlternatePayPalAddress(CreditCard card, decimal amount, string address)
        {
            return true;
        }
    }
}
