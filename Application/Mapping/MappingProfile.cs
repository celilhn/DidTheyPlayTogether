using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Famous, FamousDto>();
            CreateMap<FamousDto, Famous>();
        }
    }
}
