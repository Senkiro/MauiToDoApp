using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiToDoApp;

public partial class TodoDetailPage : ContentPage
{
    public TodoDetailPage(TodoItem item)
    {
        InitializeComponent();

        TitleLabel.Text = item.Title;
        StatusLabel.Text = item.IsCompleted ? "✅ Đã hoàn thành" : "❌ Chưa hoàn thành";
        CreatedAtLabel.Text = item.CreatedAt.ToString("dd/MM/yyyy HH:mm");
    }
}

