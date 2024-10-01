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

        // New method to update the candidate's overall score and review
        Task UpdateCandidateScoreAndReview(int candidateId, decimal overallScore, string review);

        // New method to update the score for each technology
        Task UpdateCandidateTechnologyScore(int candidateId, int technologyId, decimal score);

    }
}
