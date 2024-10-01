using intervirew_helper_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.DataAccess.Repository.IRepository
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetQuestionsByTechnologiesAndExperienceLevels(List<int> technologyIds, List<int> experienceLevelIds);
    }
}
