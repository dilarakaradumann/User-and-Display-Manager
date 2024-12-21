using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.UserDto;
using Business.Services.Abstract;
using Business.Validation.UserValidation;
using DataAccess.Repository.Abstract;
using Entities;
using FluentValidation;

namespace Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<CreateUserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var validator = new CreateUserDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(userDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var user = _mapper.Map<Entities.User>(userDto);
            await _userRepository.AddAsync(user);

            return _mapper.Map<CreateUserDto>(user);
        }

        public async Task<List<GetUserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }

    }
}
