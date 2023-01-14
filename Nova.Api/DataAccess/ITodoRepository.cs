using Nova.Api.Model;

namespace Nova.Api.DataAccess
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoDto>> GetTodos();
        Task<TodoDto> PostTodo(string description);
        Task<TodoDto> PutTodo(TodoDto dto);
    }
}