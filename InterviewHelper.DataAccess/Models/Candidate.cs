using System.ComponentModel.DataAnnotations;

namespace intervirew_helper_backend.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public int ApplicationRoleId { get; set; }  // Foreign Key to ApplicationRole
        public DateTime InterviewDate { get; set; }
        public decimal OverallScore { get; set; }
        public bool IsActive { get; set; } = true;  // Soft delete indicator

        // Navigation properties
        public ApplicationRole ApplicationRole { get; set; }
        public ICollection<CandidateTechnologyScore> CandidateTechnologyScores { get; set; }
    }

}
