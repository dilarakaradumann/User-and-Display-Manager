using Business.Dtos.TaskDto;
using Business.Services.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto taskDto)
        {
            try
            {
                var createdTask = await _taskService.CreateTaskAsync(taskDto);
                return Ok(createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // PUT: api/task/complete/{taskId}
        [HttpPut("{taskId}/complete")]
        public async Task<IActionResult> CompleteTask(int taskId)
        {
            try
            {
                var taskCompleted = await _taskService.CompleteTaskAsync(taskId);
                if (!taskCompleted)
                    return NotFound("Task not found or completed.");

                return Ok("Mission completed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
            return Ok("Task completed.");
        }

        // GET: api/task/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTasksByUserIdAsync(int userId)
        {
            try
            {
                var tasks = await _taskService.GetTasksByUserIdAsync(userId);
                if (tasks == null || tasks.Count == 0)
                    return NotFound("No task found for the user.");

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

    }
}
