using System;

namespace TodoApp.Models;
public class Todo
{
        public int Id { get; set; }          
        public string? Title { get; set; }    
        public string? Description { get; set; } 
        public bool IsCompleted { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; } 
        public int userId{ get; set; }
        public User? User { get; set; }
}
