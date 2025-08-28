using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todoModel);
        Task<Todo?> UpdateAsync(int id, bool isDone);
        Task<Todo?> DeleteAsync(int id);
        Task<bool> TodoExists(int id);
    }
}