using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using AvaloniaApplication1.Data;
using AvaloniaApplication1.Services;
using AvaloniaApplication1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    private readonly CancellationTokenSource _cts = new();
    private readonly ChatServerService _chatServer = new();
    

    public MainWindow()
    {
        InitializeComponent();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=app.db")
            .Options;

        var context = new AppDbContext(options);
        var vm = new MainWindowViewModel(context);
        DataContext = vm;

        StartChatServer(vm);
    }

    private void StartChatServer(MainWindowViewModel vm)
    {
        _ = _chatServer.StartServerAsync(message =>
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                vm.ChatMessages.Add(message);
                vm.StatusMessage = "Получено сообщение";
            });
        }, _cts.Token);
    }

    protected override void OnClosed(EventArgs e)
    {
        _cts.Cancel();
        base.OnClosed(e);
    }

    private void ExitMenuItem_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
    
    private async void RefreshStock_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            return;

        if (button.RenderTransform is not RotateTransform rotateTransform)
        {
            rotateTransform = new RotateTransform();
            button.RenderTransform = rotateTransform;
        }

        for (int angle = 0; angle <= 360; angle += 20)
        {
            rotateTransform.Angle = angle;
            await Task.Delay(15);
        }

        rotateTransform.Angle = 0;

        if (DataContext is MainWindowViewModel vm)
        {
            vm.RefreshStock();
        }
    }

    private async void Settings_Click(object? sender, RoutedEventArgs e)
    {
        var dialog = new Window
        {
            Title = "Настройки",
            Width = 300,
            Height = 150,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new TextBlock
            {
                Text = "Окно настроек пока не реализовано.",
                Margin = new Avalonia.Thickness(20)
            }
        };

        await dialog.ShowDialog(this);
    }
}