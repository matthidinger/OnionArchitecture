using System.Collections.Generic;

namespace Core.Domain
{
    public class ShoppingCart
    {
        private readonly Dictionary<Product, int> _products = new Dictionary<Product, int>();

        public IEnumerable<Product> Products
        {
            get { return _products.Keys; }
        }

        public void AddItemToCart(Product product)
        {
            if(_products.ContainsKey(product))
            {
                _products[product]++;
                return;
            }

            _products.Add(product, 1);
        }

        public void Empty()
        {
            _products.Clear();
        }
    }
}