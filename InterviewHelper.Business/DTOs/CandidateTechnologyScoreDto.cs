namespace InterviewHelper.Business.DTOs
{
    public class CandidateTechnologyScoreDto
    {
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; } // Add this property
        public int ExperienceLevelId { get; set; }
        public string ExperienceLevelName { get; set; } // Add this property
        public decimal Score { get; set; }
    }
}
