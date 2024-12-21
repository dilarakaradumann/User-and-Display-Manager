using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.TaskDto;
using DataAccess.Repository.Abstract;
using FluentValidation;

namespace Business.Validation.TaskValidation
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Task title is required.")
                .MaximumLength(200).WithMessage("The title can be up to 200 characters.");

            RuleFor(x => x.AssignedToUserId)
                .NotEmpty().WithMessage("AssignedToUserId is required.")
                .MustAsync(async (userId, cancellation) =>
                {
                    var user = await userRepository.GetByIdAsync(userId);
                    return user != null;
                }).WithMessage("AssignedToUserId must point to a valid user.");

        }
    }
}
