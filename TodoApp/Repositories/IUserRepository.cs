using System;
using TodoApp.Models;

namespace TodoApp.Repositories;

public interface IUserRepository
{

        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        User Authenticate(string username, string password);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        bool SaveChanges();

}
