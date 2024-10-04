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
    public class TechnologyRepository: ITechnologyRepository
    {
        private readonly InterviewAppDbContext _context;

        public TechnologyRepository(InterviewAppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Technology>> GetAllTechnologiesAsync()
        {
            return await _context.Technologies
                .Where(ar => ar.IsActive)
                .ToListAsync();
        }
    }
}

