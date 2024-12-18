using System;

namespace TodoApp.Models;

public class User
{
    public int Id { get; set;}
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ICollection<Todo>? Todos { get; set; }

}
