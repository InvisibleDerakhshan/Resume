using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.Models.User;
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

        public async Task<IActionResult> List(FilterUserViewModel filter)
        {
            var result =_userService.FilterAsync(filter);
            return View(result);
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

            var result = await _userService.CreateAsync(model);

            #region CheckResult
            switch (result)
            {
                case CreateUserResult.Success:
                    break;
                case CreateUserResult.Error:
                    break;
            }
            #endregion
            return View();
        }



        #region Update
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetForEditById(id);
            if (user == null)
                return NotFound();

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


            var result = await _userService.UpdateAsync(model);

            #region CheckResult
            switch (result)
            {
                case EditUserResult.Success:
                    break;
                case EditUserResult.Error:
                    break;
                case EditUserResult.UserNotFound:
                    break;
                case EditUserResult.Emailduplicated:
                    break;
                case EditUserResult.MobileDublicated:
                    break;
            }
            #endregion
            return View();
        }

        #endregion

        #endregion

        #endregion
    }
}
