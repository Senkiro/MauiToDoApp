using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace MauiToDoApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<TodoItem> TodoItems { get; set; } = new();
    private List<TodoItem> originalItems = new();

    public MainPage()
    {
        InitializeComponent();
        TodoListView.ItemsSource = TodoItems;

        // Lắng nghe khi thêm/xoá trong danh sách
        TodoItems.CollectionChanged += (s, e) => UpdateRemainingCount();
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        var text = TodoEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        // Kiểm tra trùng tên (không phân biệt hoa thường)
        if (TodoItems.Any(item => item.Title.Equals(text, StringComparison.OrdinalIgnoreCase)))
        {
            DisplayAlert("Trùng công việc", "Công việc này đã tồn tại!", "OK");
            return;
        }

        // Tạo item mới và gán callback cập nhật đếm
        var newItem = new TodoItem(text);
        originalItems.Add(newItem);
        newItem.OnIsCompletedChanged = UpdateRemainingCount;

        TodoItems.Add(newItem);
        TodoEntry.Text = string.Empty;

        UpdateRemainingCount();
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var item = swipeItem?.BindingContext as TodoItem;
        if (item != null)
        {
            originalItems.Remove(item);
            TodoItems.Remove(item);
            UpdateRemainingCount();
        }
    }

    private void UpdateRemainingCount()
    {
        int remaining = TodoItems.Count(item => !item.IsCompleted);
        RemainingLabel.Text = $"Còn lại: {remaining} công việc";
    }

    private void OnSortChanged (object senderb, EventArgs e)
    {
        var selected = SortPicker.SelectedIndex;

        IEnumerable<TodoItem> sorted = originalItems;

        switch (selected)
        {
            case 1:
                sorted = originalItems.OrderByDescending(item => item.CreatedAt);
                break;

            case 2:
                sorted = originalItems
                    .OrderBy(item => item.IsCompleted)
                    .ThenBy(item => item.CreatedAt);
                break;
        }

        TodoItems.Clear();
        foreach (var item in sorted)
        {
            TodoItems.Add(item);
        }
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string keyword = e.NewTextValue?.ToLower().Trim();

        if (string.IsNullOrWhiteSpace(keyword))
        {
            TodoItems.Clear();
            foreach(var item in originalItems)
            {
                TodoItems.Add(item);
            }
        }
        else
        {
            var filtered = originalItems
                            .Where(x => x.Title.ToLower().Contains(keyword))
                            .ToList();

            TodoItems.Clear();
            foreach (var item in filtered)
            {
                TodoItems.Add(item);
            }
        }
    }
}
