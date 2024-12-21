using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.TaskDto;

namespace Business.Dtos.UserDto
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
