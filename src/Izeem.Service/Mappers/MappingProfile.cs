using AutoMapper;
using Izeem.Domain.Entities.Users;
using Izeem.Service.DTOs.Users;

namespace Izeem.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserCreationDto>().ReverseMap();
    }
}