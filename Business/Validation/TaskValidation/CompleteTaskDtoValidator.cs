using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.Abstract;
using FluentValidation;

namespace Business.Validation.TaskValidation
{
    public class CompleteTaskDtoValidator : AbstractValidator<int> // cause of taskId is int
    {
        private readonly ITaskRepository _taskRepository;

        public CompleteTaskDtoValidator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            RuleFor(taskId => taskId)
                .MustAsync(TaskExist).WithMessage("Task does not exist in the system.");
        }
        private async Task<bool> TaskExist(int taskId, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.CompleteTaskAsync(taskId);
            return task != null; 
        }
    }
}
