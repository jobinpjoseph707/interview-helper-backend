using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;

namespace intervirew_helper_backend.services.IServices
{
    public interface IUserService
    {
        Task<bool> IsUserExist(string username);
        Task AddUser(User user);
        Task<User> ValidateUser(string username, string password);
    }

}
