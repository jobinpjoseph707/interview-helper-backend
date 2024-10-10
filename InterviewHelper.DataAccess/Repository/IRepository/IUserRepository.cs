using intervirew_helper_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intervirew_helper_backend.Repository.IRepository
{
    namespace intervirew_helper_backend.Repository.IRepository
    {
        public interface IUserRepository
        {
            Task<User> GetUserByUsernameAsync(string username);
            Task AddUser(User user);
        }
    }

}


