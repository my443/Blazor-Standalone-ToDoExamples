using ToDo.Client.Models;

namespace ToDo.Client.Data
{
    public class AppDbContext
    {
        public List<ToDoItem> ToDoItems { get; set; }

        public AppDbContext()
        {
            ToDoItems = new List<ToDoItem> { 
                new ToDoItem { Id = 1, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 16) },
                new ToDoItem { Id = 2, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 16) },
                new ToDoItem { Id = 3, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 16) },
                new ToDoItem { Id = 4, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 16) },
                new ToDoItem { Id = 5, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 15) },
                new ToDoItem { Id = 6, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 15) },
                new ToDoItem { Id = 7, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 17) },
                new ToDoItem { Id = 8, Title = "First Item", IsDone = false, ItemDate = new DateOnly(2024, 11, 17) },
                                        };
        }
    }
}
