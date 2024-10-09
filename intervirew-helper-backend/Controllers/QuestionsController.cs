using InterviewHelper.Business.DTOs;
using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace intervirew_helper_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("get-questions")]
        public async Task<ActionResult<IEnumerable<RoleResultResponse>>> GetQuestions([FromBody] QuestionRequest request)
        {
            var result = await _questionService.GetQuestions(request);

            if (result == null)
            {
                return BadRequest("Invalid request or no technologies provided.");
            }

            return Ok(result);
        }
        // New method to update candidate's overall score and review
        [HttpPost("update-candidate-score")]
        public async Task<IActionResult> UpdateCandidateScore([FromBody] UpdateCandidateScoreRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }
            await _questionService.UpdateCandidateScoreAndReview(request.CandidateId, request.OverallScore, request.Review);
/*            return Ok("Candidate score and review updated successfully.");
*/            return Ok(new { message = "Score updated successfully." }); // Ensure a JSON response is returned

        }

        // New method to update individual technology scores
        [HttpPost("update-technology-scores")]
        public async Task<IActionResult> UpdateTechnologyScores([FromBody] UpdateTechnologyScoresRequest request)
        {
            await _questionService.UpdateCandidateTechnologyScore(request.CandidateId, request.TechnologyScores);
            /*            return Ok("Technology scores updated successfully.");
             *            
            */
            return Ok(new { message = "Score updated successfully." }); // Ensure a JSON response is returned
        }

    }
}
