using AutoMapper;
using dev.eduardroid.services.Data.Entities;
using dev.eduardroid.services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.eduardroid.services.Data
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(m => m.UserId , mf => mf.MapFrom(u=>u.Id))
                .ForMember(m => m.UserEmail , mf => mf.MapFrom(u=>u.Email))
                .ForMember(m => m.UserNickname , mf => mf.MapFrom(u=>u.Nickname))
                .ForMember(m => m.UserPassword , mf => mf.MapFrom(u=>u.Password))
                .ReverseMap();

            CreateMap<NavigationRight, NavigationRightViewModel>()
                .ForMember(m => m.NavigationRightId, mf => mf.MapFrom(u => u.Id))
                .ForMember(m => m.NavigationRightWebPage, mf => mf.MapFrom(u => u.WebPage))
                .ReverseMap();
        }
    }
}
