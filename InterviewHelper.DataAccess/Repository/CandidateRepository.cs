using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace intervirew_helper_backend.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly InterviewAppDbContext _context;

        public CandidateRepository(InterviewAppDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> AddCandidateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync(); // Ensure this is awaited if it's an async method
            return candidate; // Return the candidate
        }

        public async Task<Candidate> GetCandidateByIdAsync(int candidateId)
        {
            return await _context.Candidates.FindAsync(candidateId);
        }
    }

}
