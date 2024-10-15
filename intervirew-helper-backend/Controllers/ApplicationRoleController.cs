using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace intervirew_helper_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize] // This will ensure that only valid tokens can access this controller

    public class ApplicationRoleController : ControllerBase
    {
        private readonly IApplicationRoleService _applicationRoleService;

        
        public ApplicationRoleController(IApplicationRoleService applicationRoleService)
        {
            _applicationRoleService = applicationRoleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationRole>>> GetAllApplicationRoles()
        {
            var roles = await _applicationRoleService.GetAllApplicationRolesAsync();
            if (roles == null || !roles.Any()) // Check for null or empty list
                return NotFound();
            return Ok(roles);
        }
    }
}
