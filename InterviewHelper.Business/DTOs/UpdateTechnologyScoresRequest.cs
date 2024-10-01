using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.DTOs
{
    // DTO/UpdateTechnologyScoresRequest.cs

    public class UpdateTechnologyScoresRequest
    {
        public int CandidateId { get; set; }
        public Dictionary<int, decimal> TechnologyScores { get; set; } // Key: TechnologyId, Value: Score
    }

}
