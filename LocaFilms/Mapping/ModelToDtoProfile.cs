using AutoMapper;
using LocaFilms.Dtos;
using LocaFilms.Models;

namespace LocaFilms.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<UserModel, UserDto>();
        }
    }
}
