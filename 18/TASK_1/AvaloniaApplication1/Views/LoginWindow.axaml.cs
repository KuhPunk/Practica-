using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class LoginWindow : Window
{
    private readonly LoginViewModel _vm;

    public LoginWindow()
    {
        InitializeComponent();

        _vm = new LoginViewModel();
        Console.WriteLine($"LoginWindow VM: {_vm.GetHashCode()}");

        _vm.LoginSucceeded += OnLoginSucceeded;
        DataContext = _vm;
    }

    private void OnLoginSucceeded()
    {
        Console.WriteLine("OnLoginSucceeded CALLED");

        var mainWindow = new MainWindow();

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = mainWindow;
        }

        mainWindow.Show();
        Close();
    }
}