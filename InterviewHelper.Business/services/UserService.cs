using System.Threading.Tasks;
using BCrypt.Net;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository;
using intervirew_helper_backend.Repository.IRepository.intervirew_helper_backend.Repository.IRepository;
using intervirew_helper_backend.services.IServices;

namespace intervirew_helper_backend.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsUserExist(string userName)
        {
            var user = await _userRepository.GetUserByUsernameAsync(userName);
            return user != null;
        }

        public async Task AddUser(User user)
        {
            user.UserPassword = BCrypt.Net.BCrypt.HashPassword(user.UserPassword);

            // Add logic to hash password here if needed
            await _userRepository.AddUser(user);
        }
        public async Task<User> ValidateUser(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.UserPassword)) // Assuming you're hashing passwords
            {
                return null;
            }
            return user;
        }

    }
}
