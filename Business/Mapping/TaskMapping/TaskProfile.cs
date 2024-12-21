using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.TaskDto;
using Business.Dtos.UserDto;
using Entities;

namespace Business.Mapping.TaskMapping
{ 
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            // Task entity => TaskDto 
            CreateMap<Entities.Task, GetTaskDto>()
                .ForMember(dest => dest.AssignedToUserFullName, opt => opt.MapFrom(src => src.AssignedToUser.Name)); 

            // TaskCreateDto => Task entity 
            CreateMap<CreateTaskDto, Entities.Task>();

            // Task entity -> TaskCreateDto 
            CreateMap<Entities.Task, CreateTaskDto>();
        }
    }

}
