namespace InterviewHelper.Business.DTOs
{
    public class RoleResultResponse
    {
        public string Name { get; set; }  // Role/technology name
        public int TechnologyId { get; set; }  // Add TechnologyId field
        public List<QuestionResponse> Questions { get; set; }
    }
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Role { get; set; }
        public string Answer { get; set; } = null;  // Add the Answer property, initialized to null

    }

}
