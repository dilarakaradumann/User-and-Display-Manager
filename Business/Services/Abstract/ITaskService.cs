using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.TaskDto;

namespace Business.Services.Abstract
{
    public interface ITaskService
    {
        Task<CreateTaskDto> CreateTaskAsync(CreateTaskDto taskDto);
        Task<List<GetTaskDto>> GetAllTasksAsync();
        Task<bool> CompleteTaskAsync(int taskId);
        Task<List<CreateTaskDto>> GetTasksByUserIdAsync(int userId);  // Distribution of user tasks
    }
}
