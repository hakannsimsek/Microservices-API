using AutoMapper;
using SecondService.Dtos;
using SecondService.Models;

namespace SecondService.Profiles
{
    public class SecondsProfile : Profile
    {
        public SecondsProfile()
        {
            CreateMap<Platform, FirstReadDto>();
            CreateMap<SecondCreateDto, Second>();
            CreateMap<Second,SecondReadDto>();
        }
    }
}
