using AutoMapper;
using LocaFilms.Dtos;
using LocaFilms.Enums;
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

            CreateMap<UpdateUserDto, UserModel>();

            CreateMap<CreateMovieDto, MovieModel>()
                .ForMember(dest =>
                dest.IsAvailable,
                opt => opt.MapFrom(_ => true))

                .ForMember(dest =>
                dest.RegistrationDateTime,
                opt => opt.MapFrom(_ => DateTime.Now))
                
                .ForMember(dest =>
                dest.LastModifiedDateTime,
                opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateMovieDto, MovieModel>()
                .ForMember(dest =>
                dest.LastModifiedDateTime,
                opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<CreateRentalDto, MovieRentals>()
                .ForMember(dest =>
                dest.RentalStatus,
                opt => opt.MapFrom(_ => RentalStatusEnum.EmAndamento))

                .ForMember(dest =>
                dest.PaymentStatus,
                opt => opt.MapFrom(_ => PaymentStatusEnum.Pendente));

            CreateMap<UpdateRentalDto, MovieRentals>();
        }
    }
}
