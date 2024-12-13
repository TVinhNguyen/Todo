using System;
using Todo_restApi.Models;

namespace Todo_restApi.Repositories;

 public interface ITodoRepository
{
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(int id);
        void AddTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(int id);
        bool SaveChanges();
}