using TodoApp.DTOs;
using System.Collections.Generic;

namespace TodoApp.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoReadDto> GetTodosByUserId(int userId);

        TodoReadDto GetTodoByIdAndUserId(int id, int userId);
        
        TodoReadDto CreateTodoForUser(TodoCreateDto todoCreateDto, int userId);

        void UpdateTodoForUser(int id, int userId, TodoUpdateDto todoUpdateDto);

        void DeleteTodoForUser(int id, int userId);
    }
}
