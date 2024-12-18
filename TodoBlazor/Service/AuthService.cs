using System;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;

namespace TodoBlazor.Service;

public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {

            try
            {

                var loginData = new { username, password };
                var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var authResponse = JsonConvert.DeserializeObject<AuthResponse>(jsonResponse);
                    if (authResponse != null && authResponse.Token != null)
                    {
                        return authResponse.Token;
                    }
                    else
                    {
                        Console.WriteLine("Token extraction failed or token is null.");
                    }
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Login failed: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }


        public async Task<bool> RegisterAsync(string username, string password)
        {
            var registerData = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registerData);

            return response.IsSuccessStatusCode;
        }
    }

    public class AuthResponse
    {
        public string? Token { get; set; }
    }