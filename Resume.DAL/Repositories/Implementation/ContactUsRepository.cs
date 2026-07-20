using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Resume.DAL.ViewModels.ContactUs.FiltercontactUsViewModel;

namespace Resume.DAL.Repositories.Implementation
{
    public class ContactUsRepository : IContactUsRepository
    {
        #region Fields
        private readonly ResumeContext _context;


        #endregion

        #region Constructor
        public ContactUsRepository(ResumeContext context)
        {
            _context = context;
        }


        #endregion

        #region Methods

        public async Task InsertAsync(ContactUs contactUs)
        {
            await _context.ContactUs.AddAsync(contactUs);
        }


        public async Task<FiltercontactUsViewModel> FilterAsync(FiltercontactUsViewModel model)
        {
            var query = _context.ContactUs.AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(model.firstName))
            {
                query = query.Where(contactUs => EF.Functions.Like(contactUs.FirstName, $"%{model.firstName}%"));
            }

            if (!string.IsNullOrEmpty(model.LastName))
            {
                query = query.Where(contactUs => EF.Functions.Like(contactUs.LastName, $"%{model.LastName}%"));
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                query = query.Where(contactUs => EF.Functions.Like(contactUs.Email, $"%{model.Email}%"));
            }

            if (!string.IsNullOrEmpty(model.Mobile))
            {
                query = query.Where(contactUs => EF.Functions.Like(contactUs.Mobile, $"%{model.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(contactUs => EF.Functions.Like(contactUs.Title, $"%{model.Title}%"));
            }

            switch (model.AnswerStatus)
            {
                case FiltercontactUsAnswerStatus.All:
                    break;
                case FiltercontactUsAnswerStatus.Answered:
                    query = query.Where(contactUs => contactUs.Answer != null);
                    break;

                case FiltercontactUsAnswerStatus.Notanswered:
                    query = query.Where(contactUs => contactUs.Answer == null);
                    break;
            }

            #endregion

            query = query.OrderByDescending(contactUs => contactUs.CreateDate);

            #region Pagination

            await model.Paging(query.Select(contactUs => new ContactUsDetailsViewModel()
            {
                Answer = contactUs.Answer,
                ContactUsId = contactUs.Id,
                Description = contactUs.Description,
                Email = contactUs.Email,
                FirstName = contactUs.FirstName,
                LastName = contactUs.LastName,
                Mobile = contactUs.Mobile,
                Title = contactUs.Title,
                CreateDate = contactUs.CreateDate
            }));

            #endregion

            return model;
        }

        public async Task<ContactUsDetailsViewModel> GetInfoByIdAsync(int id)
        {
            return await _context.ContactUs.Select(contactUs => new ContactUsDetailsViewModel()
            {
                Answer = contactUs.Answer,
                ContactUsId = contactUs.Id,
                CreateDate = contactUs.CreateDate,
                Description = contactUs.Description,
                Email = contactUs.Email,
                FirstName = contactUs.FirstName,
                LastName = contactUs.LastName,
                Mobile = contactUs.Mobile,
                Title = contactUs.Title,

            }).FirstOrDefaultAsync(contactUS => contactUS.ContactUsId == id);
        }


        public async Task<ContactUs> GetbyIdAsync(int id)
        {
            {
                return await _context.ContactUs
                .FirstOrDefaultAsync(contactUS => contactUS.Id == id);
            }

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void update(ContactUs contactUs)
        {
            _context.ContactUs.Update(contactUs);
        }


        #endregion

    }
}
