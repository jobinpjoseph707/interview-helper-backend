using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace intervirew_helper_backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(roles);
        }
    }
}
