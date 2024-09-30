﻿using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace intervirew_helper_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var roles = await _technologyService.GetAllTechnologiesAsync();
            return Ok(roles);
        }
    }
}
