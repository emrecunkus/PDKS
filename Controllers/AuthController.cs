using Microsoft.AspNetCore.Mvc;
using PersonelGirisKontrolSistemi.Services;
using System.Threading.Tasks;

namespace PersonelGirisKontrolSistemi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController (IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var isValid = await _userService.ValidateCredentials(username, password);
            if (isValid)
            {
                // Kullanıcıyı sisteme giriş yapmış olarak işaretle
                // Örnek: ClaimsIdentity ve Cookie oluşturma
                // ...
                // if login is success
                //ViewBag.LoginMessage = "Dogru giriş";
                return RedirectToAction("Index", "Home");
            }
            // Hatalı giriş durumunda
            // Giriş sayfasını hata mesajı ile birlikte tekrar göster
            ViewBag.ErrorMessage = "Hatalı giriş. Lütfen kullanıcı adı ve şifrenizi kontrol edin.";
            return View();
        }
    }
}
