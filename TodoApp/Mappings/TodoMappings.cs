using System;
using AutoMapper;
using TodoApp.DTOs;
using TodoApp.Models;

namespace Todo_restApi.Mappings;

public class TodoMappings : Profile
{
    public TodoMappings()
    {
        CreateMap<Todo, TodoReadDto>();
        CreateMap<TodoCreateDto, Todo>();
        CreateMap<TodoUpdateDto, Todo>();
    }
}
