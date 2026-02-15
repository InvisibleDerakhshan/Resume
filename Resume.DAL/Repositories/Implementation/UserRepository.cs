using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly ResumeContext _context;


        #endregion

        #region Constructor
        public UserRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods 
        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

       public async Task<User> GetbyIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task SaveAsync()
        {
             await _context.SaveChangesAsync();
        }

        public async Task<bool> DuplicatedEmailAsync(int id, string email)
        {
            return await _context.Users.AnyAsync(user => user.Email == email && user.Id == id);

        }

        public async Task<bool> DuplicatedMobileAsync(int id, string mobile)
        {
            return await _context.Users.AnyAsync(user=>user.Mobile== mobile&&user.Id!=id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
        #endregion

    }
}
