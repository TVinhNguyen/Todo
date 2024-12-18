public interface ITokenService
{
    Task<string?> GetTokenAsync();
    Task SaveTokenAsync(string token);
    Task ClearTokenAsync();
}
