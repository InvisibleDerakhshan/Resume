using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.AboutMe;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class AboutMeController : AdminBaseController
    {
        #region fields

        private readonly IAboutMeService _aboutMeService;


        #endregion

        #region constructor

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }


        #endregion

        #region Actions

        #region List

        #endregion

        #region Edit

        public async Task<IActionResult> Edit()
        {
            var aboutme = await _aboutMeService.GetInfoAsync();

            if (aboutme == null)
                return NotFound();

            return View(aboutme);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminSiteEditAboutMeViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);

            }
            #endregion

            var result = await _aboutMeService.UpdateAsync(model);
            switch (result)
            {
                case AdminSiteEditAboutMeResult.Success:
                    TempData[SuccessMessage] = "ویرایش درباره من با موفقیت انجام شد";
                    return RedirectToAction(nameof(Edit));
                    
                case AdminSiteEditAboutMeResult.Error:
                    TempData[ErrorsMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید ";
                    break;
                case AdminSiteEditAboutMeResult.AboutMenotFound:
                    TempData[ErrorsMessage] = "درباره من پیدا نشد ";

                    break;
            }
            

            return View(model);
        }
        #endregion

        #endregion
    }
}
