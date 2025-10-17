using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UPFirst.Data;
using BC = BCrypt.Net.BCrypt;

namespace UPFirst.Views;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var name = NameBox.Text.Trim();
        var password = PasswordBox.Text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
        {
            return;
        }

        var user = App.dbContext.Users.Include(u => u.Role).FirstOrDefault(u => u.Name == name);
        if (user != null && BC.Verify(password, user.Password))
        {
            CurrentUser.currentUser = user;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        else
        {
            return;
        }
    }

    private void RegisterButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var name = NameBox.Text.Trim();
        var password = PasswordBox.Text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
        {
            return;
        }

        if (App.dbContext.Users.Any(u => u.Name == name))
        {
            return;
        }

        var userRole = App.dbContext.Roles.FirstOrDefault(r => r.Title == "user");
        if (userRole == null)
            return;

        var user = new User
        {
            Name = name,
            Password = BC.HashPassword(password),
            RoleId = userRole.Id
        };

        App.dbContext.Users.Add(user);
        App.dbContext.SaveChanges();

        CurrentUser.currentUser = user;
        var mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}