using System.Data.Entity;

namespace Core.Domain
{
    public interface IDataContext
    {
        IDbSet<Product> Products { get; }
        IDbSet<Category> Categories { get; }
    }
}