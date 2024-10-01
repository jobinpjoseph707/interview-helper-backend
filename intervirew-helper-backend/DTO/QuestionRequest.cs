namespace intervirew_helper_backend.DTO
{
    public class QuestionRequest
    {
        public int CandidateId { get; set; }
        public List<TechnologyExperience> Technologies { get; set; }
    }

    public class TechnologyExperience
    {
        public int TechnologyId { get; set; }  // ID of the technology
        public int ExperienceLevelId { get; set; }  // ID of the experience level
    }

}
