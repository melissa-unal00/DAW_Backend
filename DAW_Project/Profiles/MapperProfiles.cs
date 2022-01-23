using DAW_Project.DTOs;
using DAW_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DAW_Project.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //User
            CreateMap<User, RespondUserDTO>();
            CreateMap<RegisterUserDTO, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, LoginUserDTO>();
            CreateMap<User, TokenUserDTO>();

        }

    }
}
    