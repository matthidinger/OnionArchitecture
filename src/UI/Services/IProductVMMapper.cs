using Core.Domain;
using UI.Models;

namespace UI.Services
{
    public interface IProductVMMapper
    {
        ProductInput Map(Product p);
    }
}