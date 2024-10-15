using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intervirew_helper_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This will ensure that only valid tokens can access this controller

    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technology>>> GetAllTechnologies()
        {
            var technologies = await _technologyService.GetAllTechnologiesAsync();
            if (technologies == null || !technologies.Any()) 
            {
                return NotFound(); 
            }
            return Ok(technologies);
        }
    }
}
