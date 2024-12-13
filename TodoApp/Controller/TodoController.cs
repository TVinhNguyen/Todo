using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo_restApi.DTOs;
using Todo_restApi.Exceptions;
using Todo_restApi.Services;

namespace Todo_restApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public IActionResult GetAll() => Ok(_todoService.GetAllTodos());

        [HttpGet("{id:int}", Name = "GetTodoById")]
       public IActionResult GetById(int id)
        {
            try
            {
                var todo = _todoService.GetTodoById(id);
                return Ok(todo);
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message }); 
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody] TodoCreateDto todoCreateDto) {
            var newTodo = _todoService.CreateTodo(todoCreateDto);
            return CreatedAtAction(nameof(GetById), new {id = newTodo.Id},newTodo);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoUpdateDto todoUpdateDto)
        {
            try {
                _todoService.UpdateTodo(id, todoUpdateDto);
                return NoContent();

            }
            catch (TodoNotFoundException ex) {
                return NotFound(new { Message = ex.Message }); 
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                _todoService.DeleteTodo(id);
                return NoContent();
            }
            catch (TodoNotFoundException) {
                return NotFound();
            }
        }

    }
}
