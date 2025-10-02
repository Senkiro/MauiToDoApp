using System.ComponentModel;

namespace MauiToDoApp;

public class TodoItem : INotifyPropertyChanged
{
<<<<<<< HEAD
    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

=======
    public string Title { get; set; }
<<<<<<< HEAD
>>>>>>> ecfcb6d406a6bc260cc3e57a899bb2427741552f
=======
>>>>>>> ecfcb6d406a6bc260cc3e57a899bb2427741552f
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
<<<<<<< HEAD
<<<<<<< HEAD
                OnPropertyChanged(nameof(IsCompleted));
=======

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
>>>>>>> ecfcb6d406a6bc260cc3e57a899bb2427741552f
=======

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
>>>>>>> ecfcb6d406a6bc260cc3e57a899bb2427741552f
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

