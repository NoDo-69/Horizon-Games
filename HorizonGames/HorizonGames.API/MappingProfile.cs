using AutoMapper;
using HorizonGames.API.Models;
using HorizonGames.API.Models.DTOS;

namespace HorizonGames.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GamesDTO>();
            CreateMap<User, UsersDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<LoginUserDTO, User>();
        }
    }
}
