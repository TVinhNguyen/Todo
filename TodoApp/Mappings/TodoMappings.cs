using System;
using AutoMapper;
using Todo_restApi.DTOs;
using Todo_restApi.Models;

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
