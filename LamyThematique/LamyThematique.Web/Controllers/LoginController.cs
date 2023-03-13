using System.Threading.Tasks;
using System.Web.Mvc;
using LamyThematique.Domain.User.Interfaces.Services;
using LamyThematique.ViewModels.Web.Models.Authentication;

namespace LamyThematique.Web.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private IUserAuthenticationService UserAuthenticationService { get; set; }

        public LoginController(IUserAuthenticationService userAuthenticationService)
        {
            UserAuthenticationService = userAuthenticationService;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            var model = new AuthenticationFormViewModel();

            return View(model);
        }

        [HttpPost]
        [Route("Connect")]
        public async Task<ActionResult> Connect(AuthenticationFormViewModel form)
        {
            var result = await UserAuthenticationService.AuthenticateUserAsync(form);

            if (result.ResultCode == "ok")
            {
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(result.ClaimsIdentity),
                //    new AuthenticationProperties
                //    {
                //        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(3),
                //        IsPersistent = true,
                //        IssuedUtc = DateTime.UtcNow
                //    });
            }

            return RedirectToAction("Test", "Home");
        }
    }
}
