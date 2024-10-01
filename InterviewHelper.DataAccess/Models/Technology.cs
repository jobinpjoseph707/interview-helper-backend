using System.ComponentModel.DataAnnotations;

namespace intervirew_helper_backend.Models
{
    public class Technology
    {
        [Key]
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<Question> Questions { get; set; }
        public ICollection<CandidateTechnologyScore> CandidateTechnologyScores { get; set; }
    }

}
