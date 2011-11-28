using Core.Domain;

namespace Core.Services
{
    public interface IUserSession
    {
        ShoppingCart Cart { get;  }
    }
}