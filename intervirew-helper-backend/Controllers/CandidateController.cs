using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intervirew_helper_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // This will ensure that only valid tokens can access this controller

    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // POST: api/Candidates
        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(CandidateDto candidateDto)
        {
            var createdCandidate = await _candidateService.CreateCandidateAsync(candidateDto);
            return CreatedAtAction(nameof(GetCandidateById), new { id = createdCandidate.CandidateId }, createdCandidate);
        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateById(int id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredCandidates([FromQuery] string name, [FromQuery] int? roleId, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            try
            {
                var candidates = await _candidateService.GetFilteredCandidatesAsync(name, roleId, fromDate, toDate);
                return Ok(candidates);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}



