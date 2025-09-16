using System.Collections.ObjectModel;

namespace MauiToDoApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<TodoItem> TodoItems { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        TodoListView.ItemsSource = TodoItems;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        var text = TodoEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(text))
        {
            TodoItems.Add(new TodoItem(text)); 
            TodoEntry.Text = string.Empty;
        }
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var item = swipeItem?.BindingContext as TodoItem; 
        if (item != null)
        {
            TodoItems.Remove(item);
        }
    }
}
