using TodoBlazor.Models;

namespace TodoBlazor.Services;
public class TodoService
{
    private readonly HttpClient _httpClient;
    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        // return await _httpClient.GetFromJsonAsync<IEnumerable<Todo>>("api/todo");
        return await Task.FromResult(new List<Todo>
        {
            new Todo { Id = 1, Title = "Sample Todo 1", Description = "Description 1", IsCompleted = false, CreatedAt = DateTime.Now },
            new Todo { Id = 2, Title = "Sample Todo 2", Description = "Description 2", IsCompleted = true, CreatedAt = DateTime.Now }
        });
    }
    public async Task<Todo?> GetTodoByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Todo>($"api/Todo/{id}");
    }
    public async Task CreateTodoAsync(Todo todo)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Todo", todo);
        response.EnsureSuccessStatusCode();
    }
    public async Task UpdateTodoAsync(int id, Todo todo)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Todo/{id}", todo);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteTodoAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Todo/{id}");
        response.EnsureSuccessStatusCode();
    }
}