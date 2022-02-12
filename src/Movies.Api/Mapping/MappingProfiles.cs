using AutoMapper;
using Movies.Core.DTOs;
using Movies.Core.Models;

namespace Movies.Api.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MovieDbResponse<MovieDbDetailResponse>, MovieResponse<MovieDetailResponse>>();
            CreateMap<MovieDbDetailResponse, MovieDetailResponse>();
        }
    }
}
