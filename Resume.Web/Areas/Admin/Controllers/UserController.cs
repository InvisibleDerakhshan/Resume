using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.User;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        private readonly IUserService _userService;


        #endregion


        #region Constructor

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion



        #region Actions

        #region List

        public async Task<IActionResult> List()
        {
            return View();
        }

        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #endregion

            return View();
        }

        #endregion

        #region Update
        public async Task<IActionResult> Update(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #endregion

            return View();
        }

        #endregion

        #endregion
    }
}
