using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IAboutMeService
    {
        #region Admin

        Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync();
        Task<ClientSideEditAboutMeviewModel?> GetClientSideInfoAsync();
        Task<AdminSiteEditAboutMeResult> UpdateAsync( AdminSiteEditAboutMeViewModel model);
        #endregion
    }
}
