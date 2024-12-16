using System;
using AutoMapper;
using TodoApp.DTOs;
using TodoApp.Exceptions;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
     public IEnumerable<UserReadDto> GetAllUsers()
    {
        var users = _repository.GetAllUser();
        return _mapper.Map<IEnumerable<UserReadDto>>(users);
    }
    public UserReadDto GetUserById(int id)
    {
        var user = _repository.GetUserById(id);
        if (user == null) throw new UserNotFoundException();
        return _mapper.Map<UserReadDto>(user);
    }
    public UserReadDto CreateUser(UserCreateDto userCreateDto)
    {
        var user = _mapper.Map<User>(userCreateDto);
        _repository.AddUser(user);
        _repository.SaveChanges();
        return _mapper.Map<UserReadDto>(user);
    }

    public void DeleteUser(int id)
    {
        var user = _repository.GetUserById(id);
        if (user == null) throw new TodoNotFoundException();
        _repository.DeleteUser(id);
        _repository.SaveChanges();    
    }

    public void UpdateUser(int id, UserReadDto userUpdateDto)
    {
        var user = _repository.GetUserById(id);
        if (user == null) throw new UserNotFoundException();

        _mapper.Map(userUpdateDto, user);
        _repository.UpdateUser(user);
        _repository.SaveChanges();
    }
}
