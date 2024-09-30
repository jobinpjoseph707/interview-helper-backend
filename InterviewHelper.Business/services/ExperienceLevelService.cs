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
    public class ExperienceLevelService :IExperienceLevelService
    {
        private readonly IExperienceLevelRepository _experienceLevelRepository;

        public ExperienceLevelService(IExperienceLevelRepository experienceLevelRepository)
        {
            _experienceLevelRepository = experienceLevelRepository;
        }

        public async Task<IEnumerable<ExperienceLevel>> GetAllExperienceLevelsAsync()
        {
            return await _experienceLevelRepository.GetAllExperienceLevelsAsync();
        }
    }
}

