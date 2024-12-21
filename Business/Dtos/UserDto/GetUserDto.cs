using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.TaskDto;

namespace Business.Dtos.UserDto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<GetTaskDto>? Tasks { get; set; }
    }
}
