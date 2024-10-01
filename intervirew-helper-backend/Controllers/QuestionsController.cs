using intervirew_helper_backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace intervirew_helper_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly InterviewAppDbContext _context;

        public QuestionsController(InterviewAppDbContext context)
        {
            _context = context;
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
            if (request == null || !request.Technologies.Any())
            {
                return BadRequest("Invalid request or no technologies provided.");
            }

            // Create lists to hold TechnologyId and ExperienceLevelId pairs
            var technologyIds = request.Technologies.Select(te => te.TechnologyId).ToList();
            var experienceLevelIds = request.Technologies.Select(te => te.ExperienceLevelId).ToList();

            // Fetch the questions matching the technology and experience level IDs
            var questions = await _context.Questions
                .Include(q => q.Technology)  // Include the Technology relationship
                .Where(q => technologyIds.Contains(q.TechnologyId) &&
                             experienceLevelIds.Contains(q.ExperienceLevelId) &&
                             q.IsActive)  // Ensure the question is active
                .ToListAsync();

            // Group the questions by technology/role and format the response
            var groupedQuestions = questions
                .GroupBy(q => q.Technology.Name)
                .Select(group => new RoleResultResponse
                {
                    Name = group.Key,  // This is the role/technology name
                    Questions = group.Select(q => new QuestionResponse
                    {
                        Id = q.QuestionId,
                        Text = q.Text,
                        Role = group.Key,  // Role is the same as the technology name
                        Answer = null  // Initialize answer to null
                    }).ToList()
                })
                .ToList();

            return Ok(groupedQuestions);
        }

    }
}
