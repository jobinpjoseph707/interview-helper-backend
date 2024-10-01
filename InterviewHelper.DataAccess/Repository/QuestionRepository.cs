using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.DataAccess.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly InterviewAppDbContext _context;

        public QuestionRepository(InterviewAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetQuestionsByTechnologiesAndExperienceLevels(List<int> technologyIds, List<int> experienceLevelIds)
        {
            return await _context.Questions
                .Include(q => q.Technology)  // Include the Technology relationship
                .Where(q => technologyIds.Contains(q.TechnologyId) &&
                             experienceLevelIds.Contains(q.ExperienceLevelId) &&
                             q.IsActive)  // Ensure the question is active
                .ToListAsync();
        }
    }

}
