using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Services;

using System.Security.Cryptography;
using System.Text;
using AvaloniaApplication1.Models;

public class AuthService
{
    private readonly JsonStorageService _storageService;
    private readonly string _usersFilePath;

    public AuthService(string usersFilePath)
    {
        _storageService = new JsonStorageService();
        _usersFilePath = usersFilePath;
    }

    public async Task<bool> RegisterAsync(string login, string password)
    {
        var users = await _storageService.LoadAsync<List<UserModel>>(_usersFilePath);

        if (users.Any(u => u.Login.Equals(login, StringComparison.OrdinalIgnoreCase)))
            return false;

        users.Add(new UserModel
        {
            Login = login,
            PasswordHash = ComputeHash(password),
            Role = "Employee"
        });

        await _storageService.SaveAsync(_usersFilePath, users);
        return true;
    }

    public async Task<UserModel?> LoginAsync(string login, string password)
    {
        var users = await _storageService.LoadAsync<List<UserModel>>(_usersFilePath);
        var hash = ComputeHash(password);

        return users.FirstOrDefault(u =>
            u.Login.Equals(login, StringComparison.OrdinalIgnoreCase) &&
            u.PasswordHash == hash);
    }

    private string ComputeHash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes);
    }
}