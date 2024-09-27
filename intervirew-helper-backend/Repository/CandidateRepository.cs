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

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _context.Candidates.Include(c => c.ApplicationRole).Where(c => c.IsActive).ToListAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await _context.Candidates.Include(c => c.ApplicationRole)
                .FirstOrDefaultAsync(c => c.CandidateId == id && c.IsActive);
        }

        public async Task AddCandidateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCandidateAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                candidate.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }

}
