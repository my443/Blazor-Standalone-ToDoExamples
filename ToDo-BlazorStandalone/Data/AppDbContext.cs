using ToDo.Client.Models;

namespace ToDo.Client.Data
{
    public class AppDbContext
    {
        public List<ToDoItem> ToDoItems { get; set; }

        public AppDbContext()
        {

            ToDoItems = GenerateTestItems();

        }

        private List<ToDoItem> GenerateTestItems()
        {
            List<ToDoItem> ToDoItems = new List<ToDoItem>();

            for (int i = 0; i < 4; i++)
            {
                ToDoItem item = new ToDoItem { Id = i + 1, Title = "First Item", IsDone = false, ItemDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)) };
                ToDoItems.Add(item);
            }

            for (int i = 0; i < 5; i++)
            {
                ToDoItem item = new ToDoItem { Id = i + 5, Title = "First Item", IsDone = false, ItemDate = DateOnly.FromDateTime(DateTime.Now) };
                ToDoItems.Add(item);
            }

            for (int i = 0; i < 3; i++)
            {
                ToDoItem item = new ToDoItem { Id = i + 10, Title = "First Item", IsDone = false, ItemDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)) };
                ToDoItems.Add(item);
            }

            return ToDoItems;
        }
    }
}
