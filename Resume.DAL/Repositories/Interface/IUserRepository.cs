using Resume.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        #region Methods

        Task InsertAsync(User user);

        Task SaveAsync();

        Task<User> GetbyIdAsync(int id);
        Task<bool> DuplicatedEmailAsync(int id ,string email);
        Task<bool> DuplicatedMobileAsync(int id ,string mobile);

        void Update(User user); 

        #endregion
    }
}
