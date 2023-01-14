using Microsoft.EntityFrameworkCore;
using Nova.Api.Model;

namespace Nova.Api.DataAccess
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }
    }
}
