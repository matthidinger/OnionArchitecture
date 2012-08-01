using System.Collections.Generic;
using System.ServiceModel;

namespace ContosoInventoryServices
{
    [ServiceContract]
    public class ContosoInventoryService
    {
        public static Dictionary<int, bool> CurrentInventory = new Dictionary<int, bool>
            {
                {1, true},
                {2, true},
                {3, false},
                {4, true}
            };


        [OperationContract]
        public bool InStock(int productId)
        {
            return CurrentInventory.ContainsKey(productId) && CurrentInventory[productId];
        }
    }
}
