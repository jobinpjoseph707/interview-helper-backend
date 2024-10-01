using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;

namespace intervirew_helper_backend.services.IServices
{
    public interface ICandidateService
    {
        Task<Candidate> CreateCandidateAsync(CandidateDto candidateDto);
        Task<Candidate> GetCandidateByIdAsync(int candidateId);
    }

}
