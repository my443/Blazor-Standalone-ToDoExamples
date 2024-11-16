namespace ToDo.Client.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details{ get; set; }
        public bool IsDone { get; set; }
    }
}
