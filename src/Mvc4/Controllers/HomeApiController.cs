using System.Web.Http;
using Core.Domain;

namespace Mvc4.Controllers
{
    public class HomeApiController : ApiController
    {
        private readonly IDataContext _db;

        public HomeApiController(IDataContext db)
        {
            _db = db;
        }

        public string Get()
        {
            var r = _db.Products;
            return "test";
        }
    }
}
