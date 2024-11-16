using ToDo.Client.Models;

namespace ToDo.Client.Data
{
    public class AppDbContext
    {
        public List<ToDoItem> ToDoItems { get; set; }

        public AppDbContext()
        {
            ToDoItems = new List<ToDoItem> { 
                new ToDoItem { Id = 1, Title = "First Item", IsDone = false },
                new ToDoItem { Id = 2, Title = "First Item", IsDone = false },
                new ToDoItem { Id = 3, Title = "First Item", IsDone = false },
                new ToDoItem { Id = 4, Title = "First Item", IsDone = false },
                                        };
        }
    }
}
