using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Dtos
{
    public class CreateTodoRequestDto
    {
        [Required]
        [StringLength(255, ErrorMessage = "Tiêu đề không được vượt quá 255 ký tự.")]
        public string Title { get; set; } = string.Empty; 
        public bool IsDone { get; set; } 
    }
}