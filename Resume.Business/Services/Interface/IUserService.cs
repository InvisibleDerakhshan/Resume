using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IUserService
    {
        #region Methods

        Task<CreateUserResult>  CreateAsync(CreateUserViewModel model);
        Task<EditUserViewModel> GetForEditById(int  id);  
        Task<EditUserResult> UpdateAsync(EditUserViewModel model);
        Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model);//***

        #endregion
    }
}
