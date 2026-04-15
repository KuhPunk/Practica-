using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using AvaloniaApplication1.Services;

namespace AvaloniaApplication1.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private readonly AuthService _authService;

    public event Action? LoginSucceeded;

    private string _login = string.Empty;
    private string _password = string.Empty;
    private string _statusMessage = string.Empty;

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoginCommand { get; }
    public ICommand RegisterCommand { get; }

    public LoginViewModel()
    {
        var dataDir = Path.Combine(AppContext.BaseDirectory, "Data");
        _authService = new AuthService(Path.Combine(dataDir, "users.json"));

        LoginCommand = new RelayCommand(async _ => await LoginAsync());
        RegisterCommand = new RelayCommand(async _ => await RegisterAsync());
    }

    private async Task LoginAsync()
    {
        Console.WriteLine($"LoginAsync VM: {GetHashCode()}");

        var user = await _authService.LoginAsync(Login, Password);

        if (user != null)
        {
            StatusMessage = $"Вход выполнен: {user.Login}";
            Console.WriteLine("BEFORE EVENT");
            LoginSucceeded?.Invoke();
            Console.WriteLine("AFTER EVENT");
        }
        else
        {
            StatusMessage = "Неверный логин или пароль";
        }
    }
    private async Task RegisterAsync()
    {
        var ok = await _authService.RegisterAsync(Login, Password);
        StatusMessage = ok
            ? "Пользователь зарегистрирован"
            : "Такой логин уже существует";
    }
}