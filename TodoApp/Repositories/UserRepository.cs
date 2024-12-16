using System;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TodoContext _context;

        public UserRepository(TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users.ToList();
        }
        
        public User GetUserById(int id)
        {
           var user = _context.Users.Find(id);
            if (user != null)
            {
                
                return user;
            }
            return null;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);

        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

    public User Authenticate(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
