using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

