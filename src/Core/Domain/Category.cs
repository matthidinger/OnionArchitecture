using System.Collections.Generic;

namespace Core.DomainModel
{
    public class Category
    {
        public int CategoryId { get; set; }
    }
}

namespace Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; private set; }
    }
}