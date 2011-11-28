using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OrderProcessingServices
{
    public class OrderProcessorService : IOrderProcessorService
    {
        public static List<string> ValidCreditCards = new List<string>
                                                          {
                                                              "1111",
                                                              "2222",
                                                              "3333",
                                                              "4444"
                                                          };

        public bool IsCreditCardValid(string creditCardNumber)
        {
            return ValidCreditCards.Contains(creditCardNumber);
        }
    }
}
