using System;
using System.Web;
using Core.Domain;
using Core.Services;

namespace UI.Services
{
    public class HttpUserSession : IUserSession
    {
        public ShoppingCart Cart
        {
            get
            {
                var session = HttpContext.Current.Session;
                var cart = session["Cart"] as ShoppingCart;
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    session["Cart"] = cart;
                }
                return cart;

            }
        }
    }
}