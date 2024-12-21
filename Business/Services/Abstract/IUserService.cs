using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.UserDto;

namespace Business.Services.Abstract
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetAllAsync();  // all users
        Task<CreateUserDto> CreateUserAsync(CreateUserDto userDto);  // new user
    }
}
