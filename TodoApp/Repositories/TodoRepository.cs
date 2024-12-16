using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<Todo> GetTodosByUserId(int userId)
        {
            return _context.Todos.Where(t => t.userId == userId).ToList();
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
        }

        public void UpdateTodo(Todo todo)
        {
            _context.Todos.Update(todo);
        }

        public void DeleteTodo(int id)
        {
            var todo = GetTodoById(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
            }
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
