using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Mapper
{
    public static class TodoMapper
    {
        public static Todo ToTodoFromCreateDto(this CreateTodoRequestDto todoDto)
        {
            return new Todo
            {
                Title = todoDto.Title,
                IsDone = todoDto.IsDone
            };
        }

        public static TodoDto ToTodoDto(this Todo todoModel)
        {
            return new TodoDto
            {
                Id = todoModel.Id,
                Title = todoModel.Title,
                IsDone = todoModel.IsDone
            };
        }
        
        public static Todo ToTodoFromUpdateDto(this UpdateTodoRequestDto todoDto, int id)
        {
            return new Todo
            {
                Id = id,
                // Title = todoDto.Title,
                IsDone = todoDto.IsDone
            };
        }
    }
}