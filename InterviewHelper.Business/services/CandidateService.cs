using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository;
using intervirew_helper_backend.services.IServices;
using Microsoft.EntityFrameworkCore;
using AutoMapper; // Import AutoMapper namespace

namespace intervirew_helper_backend.services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly InterviewAppDbContext _dbContext;
        private readonly IMapper _mapper; // Declare a field for IMapper

        // Update the constructor to accept the repository, DbContext, and IMapper
        public CandidateService(ICandidateRepository candidateRepository, InterviewAppDbContext dbContext, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _dbContext = dbContext;
            _mapper = mapper; // Assign the injected IMapper to the field
        }

        public async Task<Candidate> CreateCandidateAsync(CandidateDto candidateDto)
        {
            // Check if the ApplicationRoleId exists in the ApplicationRoles table
            var roleExists = await _dbContext.ApplicationRoles
                .AnyAsync(ar => ar.ApplicationRoleId == candidateDto.ApplicationRoleId);

            if (!roleExists)
            {
                throw new Exception("Invalid ApplicationRoleId.");
            }

            // Map CandidateDto to Candidate using AutoMapper
            var candidate = _mapper.Map<Candidate>(candidateDto);

            // Ensure candidate.TechnologyScores is not null
            candidate.CandidateTechnologyScores = candidateDto.Technologies?.Select(t => new CandidateTechnologyScore
            {
                TechnologyId = t.TechnologyId,
                ExperienceLevelId = t.ExperienceLevelId,
                Score = t.Score,
                IsActive = true
            }).ToList() ?? new List<CandidateTechnologyScore>(); // If null, create an empty list

            // Calculate the overall score, defaulting to 0 if Technologies is null
            candidate.OverallScore = candidateDto.Technologies?.Sum(t => t.Score) ?? 0;

            // Save the candidate to the database
            return await _candidateRepository.AddCandidateAsync(candidate);
        }

        public async Task<Candidate> GetCandidateByIdAsync(int candidateId)
        {
            return await _candidateRepository.GetCandidateByIdAsync(candidateId);
        }
    }
}
