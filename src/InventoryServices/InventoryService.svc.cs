using System;
using System.Collections.Generic;

namespace InventoryServices
{
    public class InventoryService : IInventoryService
    {
        public static Dictionary<int, bool> CurrentInventory = new Dictionary<int, bool>
                                                                   {
                                                                        { 1, true},
                                                                        { 2, true},
                                                                        { 3, false},
                                                                        { 4, true}
                                                                   };

        public bool InStock(int productId)
        {
            return CurrentInventory[productId];
        }
    }
}
