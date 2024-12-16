using System;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodosByUserId(int userId);

        Todo GetTodoById(int id);

        void AddTodo(Todo todo);

        void UpdateTodo(Todo todo);

        void DeleteTodo(int id);

        bool SaveChanges();
    }
}
