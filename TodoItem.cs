namespace MauiToDoApp;

public class TodoItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TodoItem(string title)
    {
        Title = title;
        IsCompleted = false;
    }
}

