using Resume.Business.Services.Interface;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly IUserRepository _userRepository;


        #endregion

        #region Constructor

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        #endregion

        #region Methods

        public async Task<CreateUserResult> CreateAsync(CreateUserViewModel model)
        {
            User user = new User()
            {
                CreateDate = DateTime.Now,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Password = model.Password,
                IsActive = model.IsActive,
            };

            await _userRepository.InsertAsync(user);
            await _userRepository.SaveAsync();

            return CreateUserResult.Success;
        }

        #endregion

    }
}
