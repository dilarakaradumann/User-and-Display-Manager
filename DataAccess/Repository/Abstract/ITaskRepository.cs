using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Abstract
{
    public interface ITaskRepository
    {
        Task<List<Entities.Task>> GetAllTasksAsync();
        Task<Entities.Task> CompleteTaskAsync(int id);
        Task CreateTaskAsync(Entities.Task task);
        Task<Entities.User> GetUserByIdAsync(int userId);
        Task<List<Entities.Task>> GetTasksByUserIdAsync(int userId);
    }
}
