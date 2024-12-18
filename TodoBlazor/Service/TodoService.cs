using System.Net.Http.Json;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using TodoBlazor.Model;

namespace TodoBlazor.Service;

public class TodoService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public TodoService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    private async Task AddAuthorizationHeaderAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        await AddAuthorizationHeaderAsync(); // Add token
        return await _httpClient.GetFromJsonAsync<IEnumerable<Todo>>("api/Todo");
    }

    public async Task<Todo?> GetTodoByIdAsync(int id)
    {
        await AddAuthorizationHeaderAsync(); // Add token
        return await _httpClient.GetFromJsonAsync<Todo>($"api/Todo/{id}");
    }

    public async Task CreateTodoAsync(Todo todo)
    {
        await AddAuthorizationHeaderAsync(); // Add token
        var response = await _httpClient.PostAsJsonAsync("api/Todo", todo);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        await AddAuthorizationHeaderAsync(); // Add token
        var response = await _httpClient.PutAsJsonAsync($"api/Todo/{todo.Id}", todo);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTodoAsync(int id)
    {
        await AddAuthorizationHeaderAsync(); // Add token
        var response = await _httpClient.DeleteAsync($"api/Todo/{id}");
        response.EnsureSuccessStatusCode();
    }
}
