using intervirew_helper_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.DataAccess.Repository.IRepository
{
    public interface IApplicationRoleRepository
    {
        Task<IEnumerable<ApplicationRole>> GetAlApplicationRolesAsync();
        Task<ApplicationRole> GetApplicationRoleByIdAsync(int id);
        Task AddApplicationRoleAsync(ApplicationRole applicationRole);
        Task UpdateApplicationRoleAsync(ApplicationRole applicationRole);
        Task DeleteApplicationRoleAsync(int id);
    }
}
