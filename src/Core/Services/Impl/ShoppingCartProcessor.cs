using System;
using System.Linq;
using Core.Domain;

namespace Core.Services.Impl
{
    internal class ShoppingCartProcessor : IShoppingCartProcessor
    {
        private readonly IInventoryService _inventoryService;
        private readonly IOrderProcessor _orderProcessor;
        private readonly IShippingService _shippingService;
        private readonly ILogger _logger;
        private readonly IUserSession _session;

        public ShoppingCartProcessor(IInventoryService inventoryService, IOrderProcessor orderProcessor, IShippingService shippingService, ILogger logger, IUserSession session)
        {
            _inventoryService = inventoryService;
            _orderProcessor = orderProcessor;
            _shippingService = shippingService;
            _logger = logger;
            _session = session;
        }

        public string CompleteCheckout(ShoppingCart cart, CreditCard creditCard)
        {
            if (cart == null) throw new ArgumentNullException("cart");
            if (creditCard == null) throw new ArgumentNullException("creditCard");

            EnsureProductsInStock(cart);
            ValidateCreditCard(creditCard);

            var status = string.Format("Your order of {0} items has been charged to {1}! It should arrive at your door shortly!", 
                                       cart.Products.Count(),
                                       creditCard.Number);

            foreach (var product in cart.Products)
            {
                _shippingService.Ship(product);                
            }

            cart.Empty();

            _logger.Log("{0} at {1}", status, DateTime.Now);
            return status;
        }

        private void ValidateCreditCard(CreditCard creditCard)
        {
            if(!_orderProcessor.IsCreditCardValid(creditCard))
            {
                throw new InvalidOperationException("The credit card is not valid");
            }
        }

        private void EnsureProductsInStock(ShoppingCart cart)
        {
            foreach (Product product in cart.Products)
            {
                if (!_inventoryService.IsInStock(product.Id))
                {
                    throw new InvalidOperationException("The cart has some products that are out of stock");
                }
            }
        }
    }
}