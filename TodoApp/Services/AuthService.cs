using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TodoApp.Models;
using TodoApp.Repositories;
using Microsoft.Extensions.Configuration;

namespace TodoApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _secretKey = configuration["Jwt:SecretKey"];  
            _issuer = configuration["Jwt:Issuer"];  
            _audience = configuration["Jwt:Audience"];  
        }

        public string Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username or Password cannot be empty.");
            }

            var user = _repository.Authenticate(username, password);  
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),  
                    new Claim("id", user.Id.ToString()),  
                }),
                Expires = DateTime.UtcNow.AddHours(1),  
                Issuer = _issuer,  
                Audience = _audience,  
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);  
        }
    }
}
