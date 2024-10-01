using InterviewHelper.Business.services.IServices;
using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.services
{
   public class TechnologyService :ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologiesAsync()
        {
            return await _technologyRepository.GetAllTechnologiesAsync();
        }
    }
}

