using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.User
{
    public class User
    {
        #region Properties 
        public int Id { get; set; }
        public string Email { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
