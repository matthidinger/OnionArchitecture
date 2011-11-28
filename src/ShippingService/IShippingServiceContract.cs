using System.ServiceModel;
using Core;
using Core.Domain;

namespace ShippingServices
{
    [ServiceContract]
    public interface IShippingService
    {
        [OperationContract]
        string Ship(Product product);
    }
}


