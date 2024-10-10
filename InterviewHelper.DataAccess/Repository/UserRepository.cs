using System.Threading.Tasks;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository.intervirew_helper_backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace intervirew_helper_backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly InterviewAppDbContext _context;

        public UserRepository(InterviewAppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task AddUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
