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
            CreateMap<Serie, SerieDto>();
            CreateMap<SerieDto, Serie>();
            CreateMap<Film, FilmDto>();
            CreateMap<FilmDto, Film>();
        }
    }
}
