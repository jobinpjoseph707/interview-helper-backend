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
    public class ExperienceLevelRepository :IExperienceLevelRepository
    {
        private readonly InterviewAppDbContext _context;

        public ExperienceLevelRepository(InterviewAppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ExperienceLevel>> GetAllExperienceLevelsAsync()
        {
            return await _context.ExperienceLevels
                .Where(ar => ar.IsActive)
                .ToListAsync();
        }
    }
}

