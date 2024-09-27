using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository;
using intervirew_helper_backend.services.IServices;

namespace intervirew_helper_backend.services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _candidateRepository.GetAllCandidatesAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await _candidateRepository.GetCandidateByIdAsync(id);
        }

        public async Task AddCandidateAsync(Candidate candidate)
        {
            await _candidateRepository.AddCandidateAsync(candidate);
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            await _candidateRepository.UpdateCandidateAsync(candidate);
        }

        public async Task DeleteCandidateAsync(int id)
        {
            await _candidateRepository.DeleteCandidateAsync(id);
        }
    }

}
