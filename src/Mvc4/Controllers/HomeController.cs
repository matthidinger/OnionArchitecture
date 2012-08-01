using System.Web.Http;
using System.Web.Mvc;
using Core.Domain;

namespace Mvc4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataContext _db;

        public HomeController(IDataContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return Content("test");
        }
    }
}
