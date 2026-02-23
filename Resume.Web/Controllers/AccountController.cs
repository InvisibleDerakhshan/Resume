using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Account;
using System.Security.Claims;

namespace Resume.Web.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Fields
        private readonly IUserService _userService;


        #endregion

        #region Constructor

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        #endregion

        #region Actions

        #region Login

        [HttpGet("/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _userService.LoginAsync(model);

            switch (result)
            {
                case LoginResult.Success:

                    var user = await _userService.GetByEmailAsync(model.Email);


                    #region Login

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.MobilePhone, user.Mobile)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(principal, properties);

                    TempData[SuccessMessage] = "خوش آمدید!";

                    #endregion

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                    break;
                case LoginResult.Error:
                    TempData[ErrorsMessage] = "خطایی رخ داده است مجددا تلاش فرمایید ";
                    return View(model);
                case LoginResult.UserNotFound:
                    TempData[ErrorsMessage] = "کاربری یافت نشد ";
                    return View(model);

            }

            return View(model);
        }

        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            TempData[SuccessMessage] = "شما با موفقیت خارج شدید";
            return RedirectToAction("Index","Home");
        }

        #endregion

        #endregion


    }
}
