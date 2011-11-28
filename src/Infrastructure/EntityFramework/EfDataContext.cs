using System.Data.Entity;
using Core.Domain;

namespace Infrastructure.EntityFramework
{
    public class EfDataContext : DbContext, IDataContext
    {
        public EfDataContext()
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }
}