using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;

namespace intervirew_helper_backend.services.IServices
{
    public interface ICandidateService
    {
        Task<Candidate> CreateCandidateAsync(CandidateDto candidateDto);
        Task<Candidate> GetCandidateByIdAsync(int candidateId);


       
        Task<IEnumerable<Technology>> GetAllTechnologiesAsync();
        Task<IEnumerable<CandidateDto>> GetFilteredCandidatesAsync(string name, int? roleId, DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<ExperienceLevel>> GetAllExperienceLevelsAsync();
        Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync();
    }
}
