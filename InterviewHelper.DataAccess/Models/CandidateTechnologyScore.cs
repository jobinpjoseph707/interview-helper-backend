namespace intervirew_helper_backend.Models
{
    public class CandidateTechnologyScore
    {
        public int CandidateTechnologyScoreId { get; set; }
        public int CandidateId { get; set; }
        public int TechnologyId { get; set; }
        public int ExperienceLevelId { get; set; }
        public decimal Score { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public Candidate Candidate { get; set; }
        public Technology Technology { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
    }

}
