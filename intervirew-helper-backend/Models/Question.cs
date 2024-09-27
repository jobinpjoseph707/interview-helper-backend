namespace intervirew_helper_backend.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int TechnologyId { get; set; }
        public int ExperienceLevelId { get; set; }
        public int ApplicationRoleId { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public Technology Technology { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }

}
