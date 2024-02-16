using AutoMapper;
using PortfolioAPI.Core.Models;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.Utilities;
class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UserDto>();
        // .ForMember(destinationMember => destinationMember.Projects, option => option.MapFrom(src => src.Projects))


    }
}