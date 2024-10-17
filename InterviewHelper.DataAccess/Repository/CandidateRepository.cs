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
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate));
            }

            try
            {
                await _context.Candidate.AddAsync(candidate);
                await _context.SaveChangesAsync();
                return candidate;
            }
            catch (DbUpdateException ex)
            {
               
                throw new Exception("An error occurred while adding the candidate.", ex);
            }
        }

        public async Task<Candidate> GetCandidateByIdAsync(int candidateId)
        {
            var candidate = await _context.Candidate.FindAsync(candidateId);
            if (candidate == null)
            {
                throw new KeyNotFoundException($"Candidate with ID {candidateId} not found.");
            }
            return candidate;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesWithScoresAsync()
        {
            try
            {
                return await _context.Candidate
                    .Include(c => c.CandidateTechnologyScores)
                    .Where(c => c.IsActive)
                    .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while fetching candidates.", ex);
            }
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologiesAsync()
        {
            try
            {
                return await _context.Technology.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
               
                throw new Exception("An error occurred while fetching technologies.", ex);
            }
        }

        public async Task<IEnumerable<ExperienceLevel>> GetAllExperienceLevelsAsync()
        {
            try
            {
                return await _context.ExperienceLevel.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
               
                throw new Exception("An error occurred while fetching experience levels.", ex);
            }
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync()
        {
            try
            {
                return await _context.ApplicationRole.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                
                throw new Exception("An error occurred while fetching application roles.", ex);
            }
        }

        public IQueryable<Candidate> GetQueryableCandidates()
        {
            return _context.Candidate
                .Include(c => c.CandidateTechnologyScores)
                .ThenInclude(cts => cts.Technology)
                .Include(c => c.CandidateTechnologyScores)
                .ThenInclude(cts => cts.ExperienceLevel)
                .Include(c => c.ApplicationRole);
        }
    }
}
