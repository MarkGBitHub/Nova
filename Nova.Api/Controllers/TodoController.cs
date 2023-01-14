using Microsoft.AspNetCore.Mvc;
using Nova.Api.DataAccess;
using Nova.Api.Model;

namespace Nova.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> GetTodos()
        {
            return Ok(await _repository.GetTodos());
        }


        [HttpPut]
        public async Task<ActionResult<TodoDto>> PutTodo(TodoDto dto)
        {
            try
            {
                await _repository.PutTodo(dto);
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message}");
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostTodo(TodoDto todo)
        {
            try
            {
                todo = await _repository.PostTodo(todo.Description);
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message}");
            }

            return Created($"api/todo", todo);
        }


    }
}
