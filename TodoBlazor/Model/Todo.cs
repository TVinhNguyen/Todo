using System;

namespace TodoBlazor.Model;

public class Todo
{

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public override string ToString()
    {
        return $"{Title} - {(IsCompleted ? "Completed" : "Pending")}";
    }

}
