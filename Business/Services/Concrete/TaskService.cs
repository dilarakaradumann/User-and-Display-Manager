using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Entities;
using AutoMapper;
using Business.Dtos.TaskDto;
using Business.Services.Abstract;
using DataAccess.Repository.Abstract;
using Business.Validation.TaskValidation;
using DataAccess.Repository.Concrete;
using FluentValidation;

namespace Business.Services.Concrete
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateTaskDto> CreateTaskAsync(CreateTaskDto taskDto)
        {
            // Validator oluştur ve validasyon yap
            var validator = new CreateTaskDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(taskDto);

            if (!validationResult.IsValid)
            {
                // Validasyon hatası varsa exception fırlatılır
                throw new ValidationException(validationResult.Errors);
            }

            // Validasyon başarılıysa işlem yapılır
            var task = _mapper.Map<Entities.Task>(taskDto);
            await _taskRepository.CreateTaskAsync(task);

            return _mapper.Map<CreateTaskDto>(task);
        }

        public async Task<List<GetTaskDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return _mapper.Map<List<GetTaskDto>>(tasks);
        }

        public async Task<bool> CompleteTaskAsync(int taskId)
        {
            // Validator oluştur ve validasyonu yap
            var validator = new CompleteTaskDtoValidator(_taskRepository);
            var validationResult = await validator.ValidateAsync(taskId);

            if (!validationResult.IsValid)
            {
                // Validasyon hatası varsa exception fırlatılır
                throw new ValidationException(validationResult.Errors);
            }
            return true;
        }

        public async Task<List<CreateTaskDto>> GetTasksByUserIdAsync(int userId)
        {
            var tasks = await _taskRepository.GetTasksByUserIdAsync(userId);
            return _mapper.Map<List<CreateTaskDto>>(tasks);
        }
    }
}
