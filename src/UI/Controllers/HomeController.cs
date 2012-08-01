using System;
using System.Web.Mvc;
using Core.Services;

namespace UI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            _logger.Log("User visited home page at {0}", DateTime.Now);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
