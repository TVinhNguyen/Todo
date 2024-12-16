using System;
using AutoMapper;
using TodoApp.DTOs;
using TodoApp.Models;

namespace TodoApp.Mappings;

public class UserMappings : Profile
{
    public UserMappings()
     
    {
        CreateMap<User, UserReadDto>();
        CreateMap<UserCreateDto, Todo>();
        CreateMap<TodoUpdateDto, Todo>();
    }
}
