using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IContactUsService
    {
        Task<CreateContactUsResult> CreateAsync(CreateContactUsViewModel model);
        Task<FiltercontactUsViewModel> FilterAsync(FiltercontactUsViewModel model);
        Task<ContactUsDetailsViewModel> GetByIdAsync(int id);

        Task<AnswerResult> Answerasync(ContactUsDetailsViewModel model);
    }
}
