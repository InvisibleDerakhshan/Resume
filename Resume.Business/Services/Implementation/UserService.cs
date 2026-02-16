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
                Email = model.Email.Trim().ToLower(),
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

  

        public async Task<EditUserViewModel> GetForEditById(int id)
        {
            var user = await _userRepository.GetbyIdAsync(id);

            if (user == null)
                return null;
            
            return new EditUserViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                IsActive = user.IsActive,
                Id = user.Id,
            };
        }

        public async Task<EditUserResult> UpdateAsync(EditUserViewModel model)
        {
            var user =await _userRepository.GetbyIdAsync(model.Id);

            if (user == null)
                return EditUserResult.UserNotFound;

            if (await _userRepository.DuplicatedEmailAsync(user.Id, user.Email.ToLower().Trim()))
                return EditUserResult.Emailduplicated;

            if (await _userRepository.DuplicatedMobileAsync(user.Id, user.Email))
                return EditUserResult.MobileDublicated;

            user.Email = model.Email;
            user.Mobile = model.Mobile;
            user.FirstName=model.FirstName;
            user.LastName=model.LastName;
            user.IsActive = model.IsActive;

            _userRepository.Update(user);
            await _userRepository.SaveAsync();

            return EditUserResult.Success;
        }

        public async Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model)
        {
           return await _userRepository.FilterAsync(model);
           
        }
        #endregion

    }
}
