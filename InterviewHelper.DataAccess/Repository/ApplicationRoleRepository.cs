using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewHelper.DataAccess.Repository
{
    public class ApplicationRoleRepository : IApplicationRoleRepository
    {
        private readonly InterviewAppDbContext _context;

        public ApplicationRoleRepository(InterviewAppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync()
        {
            return await _context.ApplicationRoles
                .Where(ar => ar.IsActive)
                .ToListAsync();
        }
    }
}