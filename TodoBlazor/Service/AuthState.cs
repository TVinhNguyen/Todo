using System;

namespace TodoBlazor.Service;

public class AuthState
{
    public bool IsAuthenticated { get; set; }
    public string? UserName { get; set; }

    public void Login(string userName)
    {
        IsAuthenticated = true;
        UserName = userName;
    }

    public void Logout()
    {
        IsAuthenticated = false;
        UserName = null;
    }
}
