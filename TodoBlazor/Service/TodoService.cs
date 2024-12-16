using System.Net.Http.Json;
using TodoBlazor.Model;
namespace TodoBlazor.Service;

public class TodoService
{
private readonly HttpClient _httpClient;
    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Todo>>("api/Todo");

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
    public async Task UpdateTodoAsync( Todo todo)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Todo/{todo.Id}", todo);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteTodoAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Todo/{id}");
        response.EnsureSuccessStatusCode();
    }

}
