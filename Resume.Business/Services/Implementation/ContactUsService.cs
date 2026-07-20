using Resume.Business.Services.Interface;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class ContactUsService : IContactUsService
    {

        #region fields
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IEmailService _emailService;
        private readonly IViewRenderService _viewRenderService;


        #endregion


        #region Constructor

        public ContactUsService(IContactUsRepository contactUsRepository, IEmailService emailService, IViewRenderService viewRenderService)
        {
            _contactUsRepository = contactUsRepository;
            _emailService = emailService;
            _viewRenderService = viewRenderService;
        }


        #endregion

        #region Methods

        public async Task<CreateContactUsResult> CreateAsync(CreateContactUsViewModel model)
        {
            ContactUs contactUs = new ContactUs()
            {
                Answer = null,
                CreateDate = DateTime.Now,
                Description = model.Description,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Title = model.Title,
            };

            await _contactUsRepository.InsertAsync(contactUs);
            await _contactUsRepository.SaveAsync();

            return CreateContactUsResult.Success;
        }

        public async Task<FiltercontactUsViewModel> FilterAsync(FiltercontactUsViewModel model)
        {
            return await _contactUsRepository.FilterAsync(model);
        }

        public async Task<ContactUsDetailsViewModel> GetByIdAsync(int id)
        {
            return await _contactUsRepository.GetInfoByIdAsync(id);
        }


        public async Task<AnswerResult> Answerasync(ContactUsDetailsViewModel model)
        {
            var contactUs = await _contactUsRepository.GetbyIdAsync(model.ContactUsId);

            if (contactUs == null)
                return AnswerResult.ContactUsNotFound;

            if (string.IsNullOrEmpty(model.Answer))
                return AnswerResult.AnswerIsNull;

            contactUs.Answer = model.Answer;

            _contactUsRepository.update(contactUs);
            await _contactUsRepository.SaveAsync();

            string body = await _viewRenderService.RenderToStringAsync("Emails/AnswerContactUs", model);
            await _emailService.SendEmail(contactUs.Email, "پاسخ به تماس با ما ", body);

            return AnswerResult.Success;

        }

        #endregion


    }
}
