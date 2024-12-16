using System;

namespace TodoApp.Exceptions;

public class TodoNotFoundException : Exception
{
    public TodoNotFoundException() : base("Todo item not found") { }
    public TodoNotFoundException(string message) : base(message) { }
    public TodoNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
