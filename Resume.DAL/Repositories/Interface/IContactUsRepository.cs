using Resume.DAL.Models.ContactUs;
using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IContactUsRepository
    {
        Task InsertAsync(ContactUs contactUs);

        Task<FiltercontactUsViewModel> FilterAsync(FiltercontactUsViewModel model);

        Task<ContactUsDetailsViewModel>GetInfoByIdAsync(int id);
        Task<ContactUs> GetbyIdAsync(int id);

        void update(ContactUs contactUs);
        Task SaveAsync();
    }
}
