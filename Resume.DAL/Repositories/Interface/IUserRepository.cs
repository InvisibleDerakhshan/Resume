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

        #endregion
    }
}
