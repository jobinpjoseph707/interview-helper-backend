using AutoMapper;
using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InterviewHelper.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidateDto>()
                .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.CandidateTechnologyScores));

            CreateMap<CandidateDto, Candidate>()
                .ForMember(dest => dest.CandidateTechnologyScores, opt => opt.MapFrom(src => src.Technologies));

            // Map CandidateTechnologyScore to CandidateTechnologyScoreDto
            CreateMap<CandidateTechnologyScore, CandidateTechnologyScoreDto>()
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score)) 
                .ForMember(dest => dest.TechnologyId, opt => opt.MapFrom(src => src.TechnologyId))
                .ForMember(dest => dest.ExperienceLevelId, opt => opt.MapFrom(src => src.ExperienceLevelId)); 

            // Map CandidateTechnologyScoreDto to CandidateTechnologyScore
            CreateMap<CandidateTechnologyScoreDto, CandidateTechnologyScore>()
                .ForMember(dest => dest.Technology, opt => opt.Ignore())
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.TechnologyId, opt => opt.MapFrom(src => src.TechnologyId)) 
                .ForMember(dest => dest.ExperienceLevelId, opt => opt.MapFrom(src => src.ExperienceLevelId)); 
        }
    }
}
