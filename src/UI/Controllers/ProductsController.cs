using System.Web.Mvc;
using Core.Domain;
using Core.Services;

namespace UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IDataContext _db;
        private readonly IUserSession _userSession;

        public ProductsController(IDataContext db, IUserSession userSession)
        {
            _db = db;
            _userSession = userSession;
        }

        public ActionResult Index()
        {
            var products = _db.Products;
            return View(products);
        }

        public ActionResult AddToCart(int id)
        {
            var product = _db.Products.Find(id);
            _userSession.Cart.AddItemToCart(product);
            TempData["Message"] = string.Format("{0} has been added to your cart!", product.Name);

            return RedirectToAction("Index");
        }
    }
}