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
            var levels = await _experienceLevelService.GetAllExperienceLevelsAsync();

            if (levels == null || !levels.Any()) // Check if levels are null or empty
            {
                return NotFound(); // Return NotFound if no levels exist
            }

            return Ok(levels); // Return Ok with the levels if found
        }

    }
}
