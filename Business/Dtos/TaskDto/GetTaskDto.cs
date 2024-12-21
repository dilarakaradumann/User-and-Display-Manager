﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.TaskDto
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public int AssignedToUserId { get; set; } 
        public string AssignedToUserFullName { get; set; }
    }
}
