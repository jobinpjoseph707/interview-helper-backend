using InterviewHelper.Business.services.IServices;
using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.services
{
    public class ApplicationRoleService : IApplicationRoleService
    {
        private readonly IApplicationRoleRepository _applicationRoleRepository;

        public ApplicationRoleService(IApplicationRoleRepository applicationRoleRepository)
        {
            _applicationRoleRepository = applicationRoleRepository;
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync()
        {
            return await _applicationRoleRepository.GetAllApplicationRolesAsync();
        }
    }
}
