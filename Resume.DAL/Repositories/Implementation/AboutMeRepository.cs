using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class AboutMeRepository : IAboutMeRepository
    {

        #region fields

        private readonly ResumeContext _context;


        #endregion

        #region Constructor

        public AboutMeRepository(ResumeContext context)
        {
            _context = context;
        }

     
        #endregion

        #region Methods

        public async Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync()
        {
            return await _context.AboutMe
                .Select(aboutme => new AdminSiteEditAboutMeViewModel()
                {
                    Id = aboutme.Id,
                    FirstName = aboutme.FirstName,
                    LastName = aboutme.LastName,
                    Email = aboutme.Email,
                    Mobile = aboutme.Mobile,
                    BirthDate = aboutme.BirthDate,
                    Location = aboutme.Location,
                    Position = aboutme.Position

                }).FirstOrDefaultAsync();
        }

        public async Task<AboutMe> GetAsync()
        {
            return await _context.AboutMe.FirstOrDefaultAsync();
        }

        public  void Update(AboutMe aboutme)
        {
             _context.AboutMe.Update(aboutme);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ClientSideEditAboutMeviewModel?> GetClientSideInfoAsync()
        {
            return await _context.AboutMe
            .Select(aboutme => new ClientSideEditAboutMeviewModel()
            {
                Id = aboutme.Id,
                FirstName = aboutme.FirstName,
                LastName = aboutme.LastName,
                Email = aboutme.Email,
                Mobile = aboutme.Mobile,
                BirthDate = aboutme.BirthDate,
                Location = aboutme.Location,
                Position = aboutme.Position

            }).FirstOrDefaultAsync();
        }

        #endregion



    }
}
