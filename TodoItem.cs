using System.ComponentModel;

namespace MauiToDoApp;

public class TodoItem : INotifyPropertyChanged
{
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }

    private bool _isCompleted;
    public bool IsCompleted
    {
        get => _isCompleted;
        set
        {
            if (_isCompleted != value)
            {
                _isCompleted = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
                OnIsCompletedChanged?.Invoke();
            }
        }
    }

    public Action OnIsCompletedChanged { get; set; }

    public TodoItem(string title)
    {
        Title = title;
        CreatedAt = DateTime.Now;
        IsCompleted = false;
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
