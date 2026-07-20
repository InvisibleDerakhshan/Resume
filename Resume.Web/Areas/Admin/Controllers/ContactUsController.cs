using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.ContactUs;
using Resume.Web.Areas.Admin.Controllers;

namespace Resume.Web.Controllers
{
    public class ContactUsController :AdminBaseController
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

        #region List
        
        public async Task<IActionResult> List(FiltercontactUsViewModel filter)
        {
            var model = await _contactUsService.FilterAsync(filter);
            return View(model);
        }

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
        {
            var contactUs = await _contactUsService.GetByIdAsync(id);

            if (contactUs == null) { 
            
                return NotFound();
            }

            return View(contactUs);
        }


        [HttpPost]
        public async Task <IActionResult>  Details(ContactUsDetailsViewModel model)
        {
            #region Validations
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion
            var result= await  _contactUsService.Answerasync(model);
            switch (result)
            {
                case AnswerResult.Success:
                    TempData[SuccessMessage] = "پاسخ برای این تماس با ما ارسال شد";
                    return RedirectToAction("List");
                  
                case AnswerResult.ContactUsNotFound:
                    TempData[ErrorsMessage] = "تماس با ما پیدا نشد";
                    break;
            
                case AnswerResult.AnswerIsNull:
                    TempData[ErrorsMessage] = " متن پاسخ خالی است";
                    break;
            }
            return View();
        }

        #endregion

        #endregion
    }
}
