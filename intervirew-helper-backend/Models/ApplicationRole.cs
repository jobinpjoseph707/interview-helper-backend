namespace intervirew_helper_backend.Models
{
    public class ApplicationRole
    {
        public int ApplicationRoleId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Question> Questions { get; set; }
    }

}
