using System;

namespace Todo_restApi.DTOs;

public class TodoCreateDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}
