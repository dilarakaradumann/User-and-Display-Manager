using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.UserDto;
using DataAccess.Repository.Abstract;
using DataAccess.Repository.Concrete;
using FluentValidation;

namespace Business.Validation.UserValidation
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The name field is required.")
                .MaximumLength(100).WithMessage("The name can be up to 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email field is required.")
                .EmailAddress().WithMessage("Please enter a valid e-mail address.")
                .MustAsync(async (email, cancellation) =>
                {
                    var existingUser = await userRepository.GetByEmailAsync(email);
                    return existingUser == null;
                }).WithMessage("This email address is already in use.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MustAsync(BeUniqueEmail).WithMessage("A user with the same email already exists.");
        }
        private async Task<bool> BeUniqueEmail(string email,CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);
            return existingUser == null; // Eğer kullanıcı bulunursa false döndürür (email zaten var)
        }
    }
}
