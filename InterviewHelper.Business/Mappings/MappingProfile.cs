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
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score)) // Assuming there's a Score property in CandidateTechnologyScore
                .ForMember(dest => dest.TechnologyId, opt => opt.MapFrom(src => src.TechnologyId)) // Ensure TechnologyId maps correctly
                .ForMember(dest => dest.ExperienceLevelId, opt => opt.MapFrom(src => src.ExperienceLevelId)); // Ensure ExperienceLevelId maps correctly

            // Map CandidateTechnologyScoreDto to CandidateTechnologyScore
            CreateMap<CandidateTechnologyScoreDto, CandidateTechnologyScore>()
                .ForMember(dest => dest.Technology, opt => opt.Ignore()) // Ignore Technology property if it exists in the model
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score)) // Map Score from DTO
                .ForMember(dest => dest.TechnologyId, opt => opt.MapFrom(src => src.TechnologyId)) // Map TechnologyId from DTO
                .ForMember(dest => dest.ExperienceLevelId, opt => opt.MapFrom(src => src.ExperienceLevelId)); // Map ExperienceLevelId from DTO
        }
    }
}
