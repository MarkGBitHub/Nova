using Microsoft.EntityFrameworkCore;
using Nova.Api.Model;

namespace Nova.Api.DataAccess
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApiContext _context;
        public TodoRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoDto>> GetTodos() =>
            await _context.Todos
                .Select(td => new TodoDto(td.Id, td.Description, td.Completed))
                .ToListAsync();

        public async Task<TodoDto> PutTodo(TodoDto dto)
        {
            if (dto == null) throw new ArgumentNullException();

            var todo = await _context.Todos.FindAsync(dto.Id);

            if (todo is null) throw new ArgumentException($"Error updating todo with id {dto.Id}");

            todo.Description = dto.Description;
            todo.Completed = !dto.Completed;
            _context.Entry(todo).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return dto;

        }

        public async Task<TodoDto> PostTodo(string description)
        {
            var todo = new Todo { Description = description };

            await _context.Todos.AddAsync(todo);

            await _context.SaveChangesAsync();

            var dto = new TodoDto(todo.Id, todo.Description, todo.Completed);

            return dto;
        }

    }
}
