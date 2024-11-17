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
                int idnumber = i + 1;
                ToDoItem item = new ToDoItem { Id = idnumber, Title = $"Item with id {idnumber}", IsDone = false, ItemDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)) };
                ToDoItems.Add(item);
            }

            for (int i = 0; i < 5; i++)
            {
                int idnumber = i + 5;
                ToDoItem item = new ToDoItem { Id = idnumber, Title = $"Item with id {idnumber}", IsDone = false, ItemDate = DateOnly.FromDateTime(DateTime.Now) };
                ToDoItems.Add(item);
            }

            for (int i = 0; i < 3; i++)
            {
                int idnumber = i + 10;
                ToDoItem item = new ToDoItem { Id = i + 10, Title = $"Item with id {idnumber}", IsDone = false, ItemDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)) };
                ToDoItems.Add(item);
            }

            return ToDoItems;
        }
    }
}
