using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.ContactUs;
using Resume.Web.Controllers;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ContactUsController : SiteBaseController
    {
        #region Fields

        private readonly IContactUsService _contactUsService;


        #endregion

        #region Constructions

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }


        #endregion

        #region Actions

        #region ContactUs

        [HttpGet("/contact-us")]
        public IActionResult ContactUs()
        {
            return View();
        }


        [HttpPost("/contact-us")]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModel model)
        {
            #region Validationts

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

             var result = await _contactUsService.CreateAsync(model);
            switch (result)
            {
                case CreateContactUsResult.Success:
                    TempData[SuccessMessage] = "پیام شما با موفقیت ثبت شد. نتیجه از طریق ایمیل به شما اطلاع رسانی خواهد شد";
                    return RedirectToAction("ContactUs");
                case CreateContactUsResult.Erorr:
                    TempData[ErrorsMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید ";
                    break;
            }

            return View(model);

        }

        #endregion

        #endregion


    }
}
