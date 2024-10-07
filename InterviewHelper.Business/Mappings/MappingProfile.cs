using AutoMapper;
using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map from Candidate entity to CandidateDto
        CreateMap<Candidate, CandidateDto>()
            .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.CandidateTechnologyScores));

        // Map from CandidateDto to Candidate entity
        CreateMap<CandidateDto, Candidate>()
            .ForMember(dest => dest.CandidateTechnologyScores, opt => opt.MapFrom(src => src.Technologies));

        // Map from CandidateTechnologyScore entity to CandidateTechnologyScoreDto
        CreateMap<CandidateTechnologyScore, CandidateTechnologyScoreDto>()
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
            .ForMember(dest => dest.TechnologyId, opt => opt.MapFrom(src => src.TechnologyId))
            .ForMember(dest => dest.ExperienceLevelId, opt => opt.MapFrom(src => src.ExperienceLevelId))
            .ForMember(dest => dest.ExperienceLevelName, opt => opt.MapFrom(src => src.ExperienceLevel.Level)); 

        // Map from CandidateTechnologyScoreDto to CandidateTechnologyScore
        CreateMap<CandidateTechnologyScoreDto, CandidateTechnologyScore>()
            .ForMember(dest => dest.Technology, opt => opt.Ignore())
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
            .ForMember(dest => dest.TechnologyId, opt => opt.MapFrom(src => src.TechnologyId))
            .ForMember(dest => dest.ExperienceLevelId, opt => opt.MapFrom(src => src.ExperienceLevelId));
    }
}
