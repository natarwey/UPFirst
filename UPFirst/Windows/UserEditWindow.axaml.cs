using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UPFirst.Data;

namespace UPFirst.Views;

public partial class UserEditWindow : Window
{
    private readonly User _user;

    public UserEditWindow()
    {
        InitializeComponent();
        _user = new User();
        DataContext = _user;
    }

    public UserEditWindow(User user) : this()
    {
        _user = user;
        DataContext = _user;
    }

    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_user.Name))
        {
            return;
        }

        if (!decimal.TryParse(_user.Password.ToString(), out _))
        {
            return;
        }

        var db = App.dbContext;
        if (_user.Id == 0)
            db.Users.Add(_user);
        db.SaveChanges();

        Close(true);
    }

    private void CancelButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(false);
    }
}