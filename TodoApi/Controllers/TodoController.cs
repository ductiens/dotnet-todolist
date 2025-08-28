using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Dtos;
using TodoApi.Helpers;
using TodoApi.Interfaces;
using TodoApi.Mapper;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepo;
        public TodoController(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        // GET: /api/todo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<TodoDto>>(ModelState.ToString(), false, "Dữ liệu không hợp lệ."));

            var todos = await _todoRepo.GetAllAsync();
            var todoDto = todos.Select(t => t.ToTodoDto()).ToList();
            return Ok(new ApiResponse<List<TodoDto>>(todoDto, "Lấy danh sách Todo thành công."));
        }

        // GET: /api/todo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<TodoDto>(ModelState.ToString(), false, "Dữ liệu không hợp lệ."));

            var todo = await _todoRepo.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound(new ApiResponse<TodoDto>("Không tìm thấy Todo với Id đã cho.", false, "Không tìm thấy."));
            }
            return Ok(new ApiResponse<TodoDto>(todo.ToTodoDto(), "Lấy thông tin Todo thành công."));
        }


        // POST: /api/todo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequestDto todoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<TodoDto>(ModelState.ToString(), false, "Dữ liệu không hợp lệ."));

            var todoModel = todoDto.ToTodoFromCreateDto();
            await _todoRepo.CreateAsync(todoModel);
            return CreatedAtAction(nameof(GetById), new { id = todoModel.Id }, new ApiResponse<TodoDto>(todoModel.ToTodoDto(), "Tạo Todo thành công."));
        }

        // PATCH: /api/todo/{id}
        [HttpPatch("{id}")]
         public async Task<IActionResult> UpdateIsDone([FromRoute] int id, [FromBody] UpdateTodoRequestDto updateIsDoneDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<TodoDto>(ModelState.ToString(), false, "Dữ liệu không hợp lệ."));

            var todoModel = await _todoRepo.UpdateAsync(id, updateIsDoneDto.IsDone);

            if (todoModel == null)
            {
                return NotFound(new ApiResponse<TodoDto>("Không tìm thấy Todo để cập nhật trạng thái.", false, "Không tìm thấy."));
            }

            return Ok(new ApiResponse<TodoDto>(todoModel.ToTodoDto(), "Cập nhật trạng thái IsDone thành công."));
        }

        // DELETE: /api/todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<TodoDto>(ModelState.ToString(), false, "Dữ liệu không hợp lệ."));

            var todoModel = await _todoRepo.DeleteAsync(id);

            if (todoModel == null)
            {
                return NotFound(new ApiResponse<TodoDto>("Không tìm thấy Todo để xóa.", false, "Không tìm thấy."));
            }

            return Ok(new ApiResponse<TodoDto>(todoModel.ToTodoDto(), "Xóa Todo thành công."));
        }
    }
}