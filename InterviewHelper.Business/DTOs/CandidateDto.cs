using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.DTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApplicationRoleId { get; set; }
        public DateTime InterviewDate { get; set; }
        public List<CandidateTechnologyScoreDto> Technologies { get; set; } = new List<CandidateTechnologyScoreDto>();
    }

}
