using AutoMapper;
using Talks.Domain;
using Talks.Service.Models;

namespace Talks.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Talk, TalkDTO>().ReverseMap();
            CreateMap<Training, TrainingDTO>().ReverseMap();
            CreateMap<Speaker, SpeakerDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
