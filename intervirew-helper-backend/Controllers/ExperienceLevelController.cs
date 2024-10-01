using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace intervirew_helper_backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceLevelController : ControllerBase
    {
        private readonly IExperienceLevelService _experienceLevelService;

        public ExperienceLevelController(IExperienceLevelService experienceLevelService)
        {
            _experienceLevelService = experienceLevelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienceLevel>>> GetAllExperienceLevels()
        {
            var roles = await _experienceLevelService.GetAllExperienceLevelsAsync();
            return Ok(roles);
        }
    }
}
