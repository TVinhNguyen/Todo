using System;

namespace Todo_restApi.Repositories;

using Todo_restApi.Data;
using Todo_restApi.Models;

public class TodoRepository : ITodoRepository
{
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return _context.Todos.ToList();
        }

        public Todo GetTodoById(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null)
            {
                
                return todo;
            }
            return null;
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
            var todo = _context.Todos.Find(id);
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


