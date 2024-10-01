using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace intervirew_helper_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController: ControllerBase
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
    }

}

