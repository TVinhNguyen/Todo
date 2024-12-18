using Blazored.LocalStorage;

public class TokenService : ITokenService 
{
    private readonly ILocalStorageService _localStorage;

    public TokenService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task SaveTokenAsync(string token)
    {
        await _localStorage.SetItemAsync("authToken", token);
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _localStorage.GetItemAsync<string>("authToken");
    }

    public async Task ClearTokenAsync()
    {
        await _localStorage.RemoveItemAsync("authToken");
    }
}
