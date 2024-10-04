using System;
using System.Collections.Generic;

namespace InterviewHelper.Business.DTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApplicationRoleId { get; set; }
        public string ApplicationRoleName { get; set; } // Add this property
        public DateTime InterviewDate { get; set; }
        public decimal OverallScore { get; set; }
        public List<CandidateTechnologyScoreDto> Technologies { get; set; } = new List<CandidateTechnologyScoreDto>();
    }
}
