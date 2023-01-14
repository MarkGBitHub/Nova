using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nova.Api.Controllers;
using Nova.Api.DataAccess;
using Nova.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nova.Api.Tests
{
    public class TodoController_Tests
    {
        [Fact]
        public async Task GetTodos_Should_Return_ListOf_TodoDtos()
        {
            //arrange
            var repo = GetMockRepository();
            var controller = new TodoController(repo);

            //act
            var result = await controller.GetTodos();

            //assert
            Assert.NotNull(result);
            var actionResult = Assert.IsType<ActionResult<List<TodoDto>>>(result);
            var okResult= Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode== 200);
        }

        [Fact]
        public async Task PostTodo_Should_Add_Todo()
        {
            //arrange
            var repo = GetMockRepository();
            var controller = new TodoController(repo);
            var expected = new TodoDto(1, "test", false);

            //act
            var result = await controller.PostTodo(expected);

            //assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.NotNull(createdResult);
            Assert.True(createdResult.StatusCode== 201);
            var todo = Assert.IsType<TodoDto>(createdResult.Value);
            Assert.NotNull(todo);
            Assert.Equal(1, todo.Id);
        }

        [Fact]
        public async Task PutTodo_Should_Update_Toggle_Completed()
        {
            //arrange
            var repo = GetMockRepository();
            var controller = new TodoController(repo);
            var todo = new TodoDto(1, "Test", true);

            //act
            var result = await controller.PutTodo(todo);

            //assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<TodoDto>>(result);
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
