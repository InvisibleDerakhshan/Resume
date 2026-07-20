using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.User;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
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
            var result = await _userService.FilterAsync(filter);
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
                    TempData[SuccessMessage] = "کاربر جدید با موفقیت افزوده شد";
                    return RedirectToAction("List");
                    
                case CreateUserResult.Error:
                    TempData[ErrorsMessage] = "خطایی رخ داده است";
                    break;
            }
            #endregion
            return View(model);
        }



        #region Update
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetForEditById(id);
            if (user == null)
                return NotFound();

            return View(user);
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
                    TempData[SuccessMessage] = "کاربر با موفقیت ویرایش شد";
                    return RedirectToAction("List");
                    
                case EditUserResult.Error:
                    TempData[ErrorsMessage] = "خطایی رخ داده است";
                    break;
                case EditUserResult.UserNotFound:
                    TempData[ErrorsMessage] = "کاربری پیدا نشد";
                    break;
                case EditUserResult.Emailduplicated:
                    TempData[ErrorsMessage] = "ایمیل تکراری است";
                    break;
                case EditUserResult.MobileDublicated:
                    TempData[ErrorsMessage] = "شماره موبایل تکراری است";
                    break;
            }
            #endregion
            return View(model);
        }

        #endregion

        #endregion

        #endregion
    }
}
