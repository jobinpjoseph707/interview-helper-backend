using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.DTO;
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

    }
}
