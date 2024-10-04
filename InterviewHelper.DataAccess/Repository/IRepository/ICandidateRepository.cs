using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using intervirew_helper_backend.Models;

namespace intervirew_helper_backend.Repository.IRepository
{
    public interface ICandidateRepository
    {
        Task<Candidate> AddCandidateAsync(Candidate candidate);
        Task<Candidate> GetCandidateByIdAsync(int candidateId);
        IQueryable<Candidate> GetQueryableCandidates();
        Task<IEnumerable<Technology>> GetAllTechnologiesAsync();
        Task<IEnumerable<ExperienceLevel>> GetAllExperienceLevelsAsync();
        Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync();
    }
}