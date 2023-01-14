using Microsoft.EntityFrameworkCore;
using Nova.Api.DataAccess;
using Nova.Api.Model;

namespace Nova.Api.Tests
{
    public class TodoRepository_Tests
    {
        [Fact]
        public async Task GetTodo_Should_Return_ListOfTodos()
        {
            //arrange
            var repo = GetMockRepository();

            //act
            var result = await repo.GetTodos();

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<TodoDto>>(result);
        }

        [Fact]
        public async Task PostTodo_Should_Add_Todo()
        {
            //arrange
            var repo = GetMockRepository();
            var expected = "Test Description";

            //act
            var result = await repo.PostTodo(expected);

            //assert
            Assert.NotNull(result);
            Assert.IsType<TodoDto>(result);
            Assert.Equal(expected, result.Description);
        }

        [Fact]
        public async Task PutTodo_Null_Input_Should_Throw_An_Exception()
        {
            //arrange
            var repo = GetMockRepository();

            //act/assert
            _ = Assert.ThrowsAsync<NullReferenceException>(async () => await repo.PutTodo(null));
        }

        [Fact]
        public async Task PutTodo_Should_Update_Completed_Value()
        {
            //arrange
            var repo = GetMockRepository();
            var dto = new TodoDto(1, "Test", true);

            //act
            var result = await repo.PutTodo(dto);

            //assert
            Assert.NotNull(result);
            Assert.IsType<TodoDto>(result);
            Assert.True(result.Completed);
        }

        public ITodoRepository GetMockRepository()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("meolmemory")
                .Options;
            var context = new ApiContext(options);
            return new TodoRepository(context);
        }
    }
}