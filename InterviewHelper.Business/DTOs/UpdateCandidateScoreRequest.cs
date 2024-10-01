using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.DTOs
{
    public class UpdateCandidateScoreRequest
    {
        public int CandidateId { get; set; }
        public decimal OverallScore { get; set; }
        public string Review { get; set; }
    }
}
