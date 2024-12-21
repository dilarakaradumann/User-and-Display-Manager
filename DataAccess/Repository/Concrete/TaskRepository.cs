using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // All Task
        public async Task<List<Entities.Task>> GetAllTasksAsync()
        {
            return await _context.Task
                .Include(t => t.AssignedToUser) // eager loading
                .ToListAsync();
        }

        // Marks a task as completed
        public async Task<Entities.Task> CompleteTaskAsync(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task == null)
                throw new Exception("The task does not exist.");

            task.IsCompleted = true;
            await _context.SaveChangesAsync();
            return task;
        }

        // add a new task
        public async Task CreateTaskAsync(Entities.Task task)
        {
            await _context.Task.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        //find by user id
        public async Task<Entities.User> GetUserByIdAsync(int userId)
        {
            // Kullanıcıyı al
            return await _context.Users.FindAsync(userId);
        }
        //get by user id
        public async Task<List<Entities.Task>> GetTasksByUserIdAsync(int userId)
        {
            // Kullanıcıya ait görevleri filtreleyip getir
            return await _context.Task.Where(t => t.AssignedToUserId == userId).ToListAsync();
        }
    }
}

