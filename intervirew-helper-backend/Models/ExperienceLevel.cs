namespace intervirew_helper_backend.Models
{
    public class ExperienceLevel
    {
        public int ExperienceLevelId { get; set; }
        public string Level { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<Question> Questions { get; set; }
        public ICollection<CandidateTechnologyScore> CandidateTechnologyScores { get; set; }
    }

}
