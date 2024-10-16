using InterviewHelper.Business.DTOs;
using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace intervirew_helper_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This will ensure that only valid tokens can access this controller

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
            // Check if the request or technologies are invalid
            if (request == null || request.Technologies == null || !request.Technologies.Any())
            {
                return BadRequest("Invalid request or no technologies provided.");
            }

            // Call the service to get questions
            var result = await _questionService.GetQuestions(request);

            // Check if the result from the service is null or empty
            if (result == null || !result.Any())
            {
                return BadRequest("No questions found.");
            }

            return Ok(result);
        }


        [HttpPost("update-candidate-score")]
        public async Task<IActionResult> UpdateCandidateScore([FromBody] UpdateCandidateScoreRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            await _questionService.UpdateCandidateScoreAndReview(request.CandidateId, request.OverallScore, request.Review);

            // Create a dictionary to store the response message
            var response = new Dictionary<string, object>
    {
        { "message", "Score updated successfully." }
    };

            return Ok(response); // Return the dictionary as JSON
        }


        // New method to update individual technology scores
        [HttpPost("update-technology-scores")]
        public async Task<IActionResult> UpdateTechnologyScores([FromBody] UpdateTechnologyScoresRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request."); // Return a bad request if the request is null
            }

            try
            {
                await _questionService.UpdateCandidateTechnologyScore(request.CandidateId, request.TechnologyScores);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while updating technology scores."); // Optional error message
            }

            var response = new Dictionary<string, object>
    {
        { "message", "Score updated successfully." }
    };

            return Ok(response); // Return the dictionary as JSON
        }

    }
    }

