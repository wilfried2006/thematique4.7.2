using LamyThematique.Domain.User.Interfaces.Services;
using System.Web.Mvc;

namespace LamyThematique.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetUserPageService _getUserPageService;
        
        public HomeController(IGetUserPageService getUserPageService)
        {
            _getUserPageService = getUserPageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}