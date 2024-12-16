using System;
using TodoApp.DTOs;

namespace TodoApp.Services;

public interface IUserService
{
    IEnumerable<UserReadDto> GetAllUsers();
    UserReadDto GetUserById(int id);
    UserReadDto CreateUser(UserCreateDto userCreateDto);
    void UpdateUser(int id, UserReadDto userUpdateDto);
    void DeleteUser(int id);
}
