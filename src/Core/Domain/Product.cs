using System.Collections.Generic;

namespace Core.Domain
{
    public class Product
    {
        public Product()
        {
            
        }

        public Product(int productId)
        {
            Id = productId;
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; private set; }
    }
}