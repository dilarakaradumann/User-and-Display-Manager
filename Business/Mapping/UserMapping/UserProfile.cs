using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.TaskDto;
using Business.Dtos.UserDto;
using Entities;

namespace Business.Mapping.UserMapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // User -> CreateUserDto 
            CreateMap<User, CreateUserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // CreateUserDto -> User 
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // User -> GetUserDto 
            CreateMap<User, GetUserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Task.Select(t => new GetTaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsCompleted = t.IsCompleted
                }).ToList()));

            // GetUserDto -> User 
            CreateMap<GetUserDto, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Task, opt => opt.MapFrom(src =>
                    src.Tasks.Select(t => new Entities.Task
                    {
                        Title = t.Title,
                        IsCompleted = t.IsCompleted
                    }).ToList())); 

        }
    }
}
