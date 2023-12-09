using AutoMapper;
using Izeem.Domain.Entities.Users;
using Izeem.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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