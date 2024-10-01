using intervirew_helper_backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using intervirew_helper_backend.services;



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

        /*     [HttpPost("get-questions")]
             public async Task<ActionResult<IEnumerable<QuestionResponse>>> GetQuestions([FromBody] QuestionRequest request)
             {
                 if (request == null || !request.Technologies.Any())
                 {
                     return BadRequest("Invalid request or no technologies provided.");
                 }

                 // Fetch all questions from the database, but filter them client-side using AsEnumerable()
                 var questions = await _context.Questions
                     .Include(q => q.Technology)  // Include the Technology relationship
                     .AsNoTracking()  // Optional: Use AsNoTracking to improve performance if no updates are needed
                     .ToListAsync();

                 // Now filter the questions in-memory based on TechnologyId and ExperienceLevelId
                 var filteredQuestions = questions
                     .Where(q => request.Technologies
                         .Any(te => te.TechnologyId == q.TechnologyId && te.ExperienceLevelId == q.ExperienceLevelId))
                     .Select(q => new QuestionResponse
                     {
                         Id = q.QuestionId,
                         Text = q.Text,
                         Role = q.Technology.Name  // Assuming 'Role' is based on the Technology's Name
                     })
                     .ToList();

                 return Ok(filteredQuestions);
             }
     */
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
    }

}
}
