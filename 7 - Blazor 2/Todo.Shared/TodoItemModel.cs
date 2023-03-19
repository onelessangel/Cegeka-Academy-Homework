using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Shared
{
    public class TodoItemModel
    {
		public Guid? Id { get; set; }

		[Required]
		[MaxLength(100, ErrorMessage = "Please make the title shorter")]
		public string Title { get; set; } = string.Empty;

		[MaxLength(1000, ErrorMessage = "Please shorten the description")]
		public string Description { get; set; } = string.Empty;

		[DataType(DataType.Date)]
		public DateTime Deadline { get; set; } = DateTime.Now;
		public bool IsDone { get; set; }
		
        public TodoItemModel()
        {
        }

        public TodoItemModel(Guid id, string title = "", string description = "", DateTime? deadline = null, bool isDone = false)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline ?? DateTime.Now;
            IsDone = isDone;
        }
    }
}
