using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nova.Api.Model
{
    public class Todo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
    }
}
