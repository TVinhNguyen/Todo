using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.DTOs;
using TodoApp.Exceptions;
using TodoApp.Services;
using TodoApp.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace TodoApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IAuthService _authService;

        public TodoController(ITodoService todoService, IAuthService authService)
        {
            _todoService = todoService;
            _authService = authService;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            return userIdClaim != null ? int.Parse(userIdClaim) : 0;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var userIdClaim = User.FindFirst("id"); 
            if (userIdClaim == null)
            {
                return Unauthorized(new { Message = "User ID not found" });
            }
            var userId = int.Parse(userIdClaim.Value); 
            var todos = _todoService.GetTodosByUserId(userId);
            return Ok(todos);
        }

        [HttpGet("{id:int}", Name = "GetTodoById")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var userIdClaim = User.FindFirst("id"); 
            if (userIdClaim == null)
            {
                return Unauthorized(new { Message = "User ID not found" });
            }
            var userId = int.Parse(userIdClaim.Value); 
            try
            {
                var todo = _todoService.GetTodoByIdAndUserId(id, userId);
                return Ok(todo);
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] TodoCreateDto todoCreateDto)
        {
            var userIdClaim = User.FindFirst("id"); 
            if (userIdClaim == null)
            {
                return Unauthorized(new { Message = "User ID not found" });
            }
            var userId = int.Parse(userIdClaim.Value); 
            var newTodo = _todoService.CreateTodoForUser(todoCreateDto, userId);
            return CreatedAtAction(nameof(GetById), new { id = newTodo.Id }, newTodo);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] TodoUpdateDto todoUpdateDto)
        {
            var userIdClaim = User.FindFirst("id"); 
            if (userIdClaim == null)
            {
                return Unauthorized(new { Message = "User ID not found" });
            }
            var userId = int.Parse(userIdClaim.Value); 
            try
            {
                _todoService.UpdateTodoForUser(id, userId, todoUpdateDto);
                return NoContent();
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var userIdClaim = User.FindFirst("id"); 
            if (userIdClaim == null)
            {
                return Unauthorized(new { Message = "User ID not found" });
            }
            var userId = int.Parse(userIdClaim.Value);
            try
            {
                _todoService.DeleteTodoForUser(id, userId);
                return NoContent();
            }
            catch (TodoNotFoundException)
            {
                return NotFound();
            }
        }


    }
}
