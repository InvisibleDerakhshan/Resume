using Resume.Business.Services.Interface;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class AboutMeService : IAboutMeService
    {
        #region Fields

        private readonly IAboutMeRepository _aboutMeRepository;


        #endregion

        #region constructor

        public AboutMeService(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }

      

        #endregion

        #region methods




        public async Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync()
        {
            return await _aboutMeRepository.GetInfoAsync();
        }

        public async Task<ClientSideEditAboutMeviewModel?> GetClientSideInfoAsync()
        {
            return await _aboutMeRepository.GetClientSideInfoAsync();
        }
        public async Task<AdminSiteEditAboutMeResult> UpdateAsync(AdminSiteEditAboutMeViewModel model)
        {
            AboutMe aboutMe = await _aboutMeRepository.GetAsync();
            if(aboutMe == null)
                return AdminSiteEditAboutMeResult.AboutMenotFound;

            aboutMe.FirstName = model.FirstName;
            aboutMe.LastName = model.LastName;
            aboutMe.BirthDate = model.BirthDate;
            aboutMe.Email = model.Email;
            aboutMe.Mobile = model.Mobile;
            aboutMe.Position = model.Position;
            aboutMe.Location = model.Location;
            aboutMe.Bio = model.Bio;


            _aboutMeRepository.Update(aboutMe);
            await _aboutMeRepository.SaveAsync();

            return AdminSiteEditAboutMeResult.Success;
        }

        #endregion

    }
}
