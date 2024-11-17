using ToDo.Client.Data;
using ToDo.Client.Models;

namespace ToDo.Client.ViewModels
{
    public class ToDoItemViewModel
    {
        private AppDbContext context = new AppDbContext();

        public List<ToDoItem> ToDoItems;
        public List<ToDoItem> CurrentDayItems;

        private ToDoItem SelectedItem;
        public int? SelectedItemId;
        private DateOnly _selectedDate;


        public DateOnly SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    UpdateCurrentDayData(); // Call your function here
                }
            }
        }

        public ToDoItemViewModel() {
            _selectedDate = DateOnly.FromDateTime(DateTime.Now);
            SelectedDate = DateOnly.FromDateTime(DateTime.Now);
            ToDoItems = context.ToDoItems;
            CurrentDayItems = ToDoItems.Where(t => t.ItemDate == SelectedDate).ToList();
            SelectFirstItem();
        }

        public void AddItem()
        {
            int newId = GetNextId();

            ToDoItem newItem = new ToDoItem
            {
                Id = newId,
                Title = "New Item",
                IsDone = false,
                ItemDate = SelectedDate
            };

            ToDoItems.Add(newItem);
            UpdateCurrentDayData();
        }

        public void DeleteItem()
        {
            ToDoItem? itemToDelete = null;

            if (SelectedItemId.HasValue)
            {
                itemToDelete = ToDoItems.FirstOrDefault(item => item.Id == SelectedItemId.Value);
            }

            if (itemToDelete != null)
            {
                ToDoItems.Remove(itemToDelete);
                SelectFirstItem();
                UpdateCurrentDayData();
            }

        }

        public int GetNextId()
        {
            return ToDoItems.Select(item => item.Id).DefaultIfEmpty().Max() + 1;
        }
        private void SelectFirstItem()
        {
            SelectedItemId = ToDoItems.Any() ? CurrentDayItems.Min(item => (int?)item.Id) : null; // Select the first item
        }

        public void SetPreviousDay()
        {
            SelectedDate = SelectedDate.AddDays(-1);
            UpdateCurrentDayData();
        }

        public void SetNextDay()
        {
            SelectedDate = SelectedDate.AddDays(1);
            UpdateCurrentDayData();
        }

        public void SetToday()
        {
            SelectedDate = DateOnly.FromDateTime(DateTime.Now);
            UpdateCurrentDayData();
        }

        public void UpdateCurrentDayData()
        {
            CurrentDayItems = ToDoItems.Where(t => t.ItemDate == SelectedDate).ToList();
            SelectFirstItem();
            //StateHasChanged();
        }
    }
}
