using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.DTOs
{
   public class CandidateTechnologyScoreDto
    {
        public int TechnologyId { get; set; }
        public int ExperienceLevelId { get; set; }
        public decimal Score { get; set; }
    }
}
