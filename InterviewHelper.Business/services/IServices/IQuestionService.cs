using intervirew_helper_backend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.services.IServices
{
    public interface IQuestionService
    {
        Task<List<RoleResultResponse>> GetQuestions(QuestionRequest request);
    }
}
