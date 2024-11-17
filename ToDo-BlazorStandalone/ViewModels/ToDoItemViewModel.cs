using ToDo.Client.Data;
using ToDo.Client.Models;

namespace ToDo.Client.ViewModels
{
    public class ToDoItemViewModel
    {
        private AppDbContext context = new AppDbContext();

        public List<ToDoItem> ToDoItems;
        public List<ToDoItem> CurrentDayItems;



        private DateOnly _selectedDate;
        private ToDoItem _selectedItem;
        private int? _selectedItemId;

        public ToDoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                { _selectedItem = value; }
            }
        }

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

        public int? SelectedItemId
        {
            get { return _selectedItemId; }
            set {
                _selectedItemId = value;
                SelectItem();
            }
        }

        public ToDoItemViewModel()
        {
            _selectedDate = DateOnly.FromDateTime(DateTime.Now);
            SelectedDate = DateOnly.FromDateTime(DateTime.Now);
            ToDoItems = context.ToDoItems;
            CurrentDayItems = ToDoItems.Where(t => t.ItemDate == SelectedDate).ToList();
            SelectFirstItem();
        }

        public void SelectItem()
        {
            if (SelectedItemId.HasValue)
            {
                SelectedItem = ToDoItems.FirstOrDefault(item => item.Id == SelectedItemId.Value);
            }
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

            // So that it chooses the one you just added.       
            SelectedItemId = newId;
            SelectItem();
        }

        public void DeleteItem()
        {
            if (SelectedItem != null)
            {
                ToDoItems.Remove(SelectedItem);
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
            SelectItem();
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
