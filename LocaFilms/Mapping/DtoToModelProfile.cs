using AutoMapper;
using LocaFilms.Dtos;
using LocaFilms.Models;

namespace LocaFilms.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<CreateUserDto, UserModel>()
                .ForMember(dest =>
                dest.IsActive,
                opt => opt.MapFrom(_ => true))

                .ForMember(dest =>
                dest.RegistrationDate,
                opt => opt.MapFrom(_ => DateTime.Now))

                .ForMember(dest =>
                dest.Balance,
                opt => opt.MapFrom(_ => 0));
        }
    }
}
