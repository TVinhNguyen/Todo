using System;
using Todo_restApi.DTOs;

namespace Todo_restApi.Services;

public interface ITodoService
{
    IEnumerable<TodoReadDto> GetAllTodos();
    TodoReadDto GetTodoById(int id);
    TodoReadDto CreateTodo(TodoCreateDto todoCreateDto);
    void UpdateTodo(int id, TodoUpdateDto todoUpdateDto);
    void DeleteTodo(int id);
}