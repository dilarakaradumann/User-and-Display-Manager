using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Entities
{
    public class Task
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AssignedToUserId { get; set; }
        public bool IsCompleted { get; set; } = false;
        public User AssignedToUser { get; set; }
    }
}
