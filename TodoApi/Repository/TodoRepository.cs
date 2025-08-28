using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repository
{
  public class TodoRepository : ITodoRepository
  {
    private readonly ApplicationDBContext _context;

    public TodoRepository(ApplicationDBContext context)
    {
      _context = context;
    }
    public async Task<Todo> CreateAsync(Todo todoModel)
    {
      await _context.Todos.AddAsync(todoModel);
      await _context.SaveChangesAsync();
      return todoModel;
    }

    public async Task<Todo?> DeleteAsync(int id)
    {
      var todoModel = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
      if (todoModel == null)
      {
          return null;
      }

      _context.Todos.Remove(todoModel);
      await _context.SaveChangesAsync();
      return todoModel;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
      return await _context.Todos.ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
      return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> TodoExists(int id)
    {
      return await _context.Todos.AnyAsync(e => e.Id == id);
    }

    public async Task<Todo?> UpdateAsync(int id, bool isDone)
    {
      var existingTodo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
      if (existingTodo == null)
      {
          return null;
      }

      // existingTodo.Title = todoModel.Title;
      existingTodo.IsDone = isDone;

      await _context.SaveChangesAsync();
      return existingTodo;
    }
  }
}