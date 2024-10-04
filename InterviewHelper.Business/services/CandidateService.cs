using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository;
using intervirew_helper_backend.services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace intervirew_helper_backend.services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<Candidate> CreateCandidateAsync(CandidateDto candidateDto)
        {
            var applicationRoles = await _candidateRepository.GetAllApplicationRolesAsync();
            var roleExists = applicationRoles.Any(ar => ar.ApplicationRoleId == candidateDto.ApplicationRoleId);

            if (!roleExists)
            {
                throw new Exception("Invalid ApplicationRoleId.");
            }

            var candidate = _mapper.Map<Candidate>(candidateDto);

            candidate.CandidateTechnologyScores = candidateDto.Technologies?.Select(t => new CandidateTechnologyScore
            {
                TechnologyId = t.TechnologyId,
                ExperienceLevelId = t.ExperienceLevelId,
                Score = t.Score,
                IsActive = true
            }).ToList() ?? new List<CandidateTechnologyScore>();

            candidate.OverallScore = candidateDto.Technologies?.Sum(t => t.Score) ?? 0;

            return await _candidateRepository.AddCandidateAsync(candidate);
        }

        public async Task<IEnumerable<CandidateDto>> GetFilteredCandidatesAsync(string name, int? roleId, DateTime? fromDate, DateTime? toDate)
        {
            var query = _candidateRepository.GetQueryableCandidates();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (roleId.HasValue)
            {
                query = query.Where(c => c.ApplicationRoleId == roleId.Value);
            }

            if (fromDate.HasValue)
            {
                query = query.Where(c => c.InterviewDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(c => c.InterviewDate <= toDate.Value);
            }

            var candidates = await query.ToListAsync();

            return _mapper.Map<IEnumerable<CandidateDto>>(candidates);
        }


        public async Task<Candidate> GetCandidateByIdAsync(int candidateId)
        {
            return await _candidateRepository.GetCandidateByIdAsync(candidateId);
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologiesAsync()
        {
            return await _candidateRepository.GetAllTechnologiesAsync();
        }

        public async Task<IEnumerable<ExperienceLevel>> GetAllExperienceLevelsAsync()
        {
            return await _candidateRepository.GetAllExperienceLevelsAsync();
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync()
        {
            return await _candidateRepository.GetAllApplicationRolesAsync();
        }


    }
}