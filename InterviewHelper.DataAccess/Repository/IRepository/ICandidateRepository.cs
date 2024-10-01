using intervirew_helper_backend.Models;

namespace intervirew_helper_backend.Repository.IRepository
{

        public interface ICandidateRepository
        {
            Task<Candidate> AddCandidateAsync(Candidate candidate);
            Task<Candidate> GetCandidateByIdAsync(int candidateId);
        }

    

}
