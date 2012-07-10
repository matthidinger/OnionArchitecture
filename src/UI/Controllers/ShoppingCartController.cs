using System;
using System.Web.Mvc;
using Core.Domain;
using Core.Services;

namespace UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IUserSession _session;
        private readonly IShoppingCartProcessor _cartProcessor;
        private readonly IDataContext _db;

        public ShoppingCartController(IUserSession session, IShoppingCartProcessor cartProcessor, IDataContext db)
        {
            _session = session;
            _cartProcessor = cartProcessor;
            _db = db;
            
        }

        [HttpGet]
        public ActionResult Index()
        {
            var cart = _session.Cart;
            return View(cart);
        }

        [HttpPost]
        public ActionResult Checkout(CreditCard creditCard)
        {
            var cart = _session.Cart;
            try
            {
                TempData["Message"] = _cartProcessor.CompleteCheckout(cart, creditCard);
                cart.Empty();
                return View("Complete");
            }
            catch (InvalidOperationException ex)
            {
                TempData["Message"] = string.Format("We're sorry but we cannot complete your order. <b>{0}</b>.", ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}