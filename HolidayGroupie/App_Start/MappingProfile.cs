using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HolidayGroupie.Dtos;
using HolidayGroupie.Models;

namespace HolidayGroupie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Friend, FriendDto>();
            Mapper.CreateMap<FriendDto, Friend>();
        }
    }
}