using System;
using System.Collections.Generic;
using AutoMapper;
using TodoApp.DTOs;
using TodoApp.Exceptions;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public TodoService(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TodoReadDto> GetTodosByUserId(int userId)
        {
            var todos = _repository.GetTodosByUserId(userId);
            return _mapper.Map<IEnumerable<TodoReadDto>>(todos);
        }

        public TodoReadDto GetTodoByIdAndUserId(int id, int userId)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null || todo.userId != userId) // Ensure the todo belongs to the user
            {
                throw new TodoNotFoundException();
            }
            return _mapper.Map<TodoReadDto>(todo);
        }

        public TodoReadDto CreateTodoForUser(TodoCreateDto todoCreateDto, int userId)
        {
            var todo = _mapper.Map<Todo>(todoCreateDto);
            todo.CreatedAt = DateTime.UtcNow;
            todo.userId = userId;  
            _repository.AddTodo(todo);
            _repository.SaveChanges();
            return _mapper.Map<TodoReadDto>(todo);
        }

        public void UpdateTodoForUser(int id, int userId, TodoUpdateDto todoUpdateDto)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null || todo.userId != userId) 
            {
                throw new TodoNotFoundException();
            }

            _mapper.Map(todoUpdateDto, todo);
            todo.UpdatedAt = DateTime.UtcNow;
            _repository.UpdateTodo(todo);
            _repository.SaveChanges();
        }

        public void DeleteTodoForUser(int id, int userId)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null || todo.userId != userId) // Ensure the todo belongs to the user
            {
                throw new TodoNotFoundException();
            }
            _repository.DeleteTodo(id);
            _repository.SaveChanges();
        }
    }
}
