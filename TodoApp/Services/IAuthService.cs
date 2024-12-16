using System;

namespace TodoApp.Services;

public interface IAuthService
{
        string Authenticate(string username, string password);  

}