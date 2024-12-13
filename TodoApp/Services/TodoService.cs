using System;
using AutoMapper;
using Todo_restApi.DTOs;
using Todo_restApi.Exceptions;
using Todo_restApi.Models;
using Todo_restApi.Repositories;

namespace Todo_restApi.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;
    private readonly IMapper _mapper;

    public TodoService(ITodoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

   public IEnumerable<TodoReadDto> GetAllTodos()
    {
            var todos = _repository.GetAllTodos();
            return _mapper.Map<IEnumerable<TodoReadDto>>(todos);
    }

    public TodoReadDto GetTodoById(int id)
    {
        var todo = _repository.GetTodoById(id);
        if (todo == null) throw new TodoNotFoundException();
        return _mapper.Map<TodoReadDto>(todo);
    }

    public TodoReadDto CreateTodo(TodoCreateDto todoCreateDto)
    {
        var todo = _mapper.Map<Todo>(todoCreateDto);
        todo.CreatedAt = DateTime.UtcNow;
        _repository.AddTodo(todo);
        _repository.SaveChanges();
        return _mapper.Map<TodoReadDto>(todo);
    }

    public void UpdateTodo(int id, TodoUpdateDto todoUpdateDto)
    {
        var todo = _repository.GetTodoById(id);
        if (todo == null) throw new TodoNotFoundException();

        _mapper.Map(todoUpdateDto, todo);
        todo.UpdatedAt = DateTime.UtcNow;
        _repository.UpdateTodo(todo);
        _repository.SaveChanges();
    }

    public void DeleteTodo(int id)
    {
        var todo = _repository.GetTodoById(id);
        if (todo == null) throw new TodoNotFoundException();
        _repository.DeleteTodo(id);
        _repository.SaveChanges();
    }
}
