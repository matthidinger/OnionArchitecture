using System.ServiceModel;

namespace AcmeShippingServices
{
    [ServiceContract]
    public class AcmeShippingService
    {
        [OperationContract]
        public string Ship(int productId)
        {
            return string.Format("Done Shipping Product ID: {0}", productId);
        }
    }
}


