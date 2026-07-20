using Resume.DAL.Models.AboutMe;
using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IAboutMeRepository
    {
        #region Methods

        Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync();
        Task<ClientSideEditAboutMeviewModel?> GetClientSideInfoAsync();

        Task<AboutMe> GetAsync();

        void Update(AboutMe aboutme);

        Task SaveAsync();

        #endregion
    }
}
