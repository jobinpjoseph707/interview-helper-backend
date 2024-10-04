using InterviewHelper.Business.services.IServices;
using InterviewHelper.DataAccess.Repository.IRepository;
using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<RoleResultResponse>> GetQuestions(QuestionRequest request)
        {
            if (request == null || !request.Technologies.Any())
            {
                return null; // You can handle this differently as per your business rules
            }

            // Get TechnologyId and ExperienceLevelId from request
            var technologyIds = request.Technologies.Select(te => te.TechnologyId).ToList();
            var experienceLevelIds = request.Technologies.Select(te => te.ExperienceLevelId).ToList();

         /*   var techExpPairs = request.Technologies
                                      .Select(te => (te.TechnologyId, te.ExperienceLevelId))
                                      .ToList();*/
            // Get questions from repository
            var questions = await _questionRepository.GetQuestionsByTechnologiesAndExperienceLevels(technologyIds, experienceLevelIds);

            // Group the questions by technology/role and format the response

            var filteredQuestions = questions
       .Where(q => request.Technologies.Any(te => te.TechnologyId == q.TechnologyId && te.ExperienceLevelId == q.ExperienceLevelId))
       .ToList();
            var groupedQuestions = filteredQuestions
                  .GroupBy(q => new { q.Technology.Name, q.TechnologyId })
                  .Select(group => new RoleResultResponse
                  {
                      Name = group.Key.Name,  // This is the role/technology name
                      TechnologyId = group.Key.TechnologyId,  // Add the TechnologyId to the response
                      Questions = group.Select(q => new QuestionResponse
                      {
                          Id = q.QuestionId,
                          Text = q.Text,
                          Role = group.Key.Name,  // Role is the same as the technology name
                          Answer = null  // Initialize answer to null
                      }).ToList()
                  })
                  .ToList();

            return groupedQuestions;
        }
         // New method to update overall score and review
    public async Task UpdateCandidateScoreAndReview(int candidateId, decimal overallScore, string review)
    {
        await _questionRepository.UpdateCandidateScoreAndReview(candidateId, overallScore, review);
    }

    // New method to update scores for individual technologies
    public async Task UpdateCandidateTechnologyScore(int candidateId, Dictionary<int, decimal> technologyScores)
    {
        foreach (var entry in technologyScores)
        {
            await _questionRepository.UpdateCandidateTechnologyScore(candidateId, entry.Key, entry.Value);
        }
    }
    }

}
