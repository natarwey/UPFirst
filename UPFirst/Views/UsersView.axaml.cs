using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using UPFirst.Data;
using UPFirst.Views;

namespace UPFirst.Views;

public partial class UsersView : UserControl
{
    public UsersView()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        UsersDataGrid.ItemsSource = App.dbContext.Users.ToList();
    }

    private async void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var win = new UserEditWindow();
        var owner = this.VisualRoot as Window;
        if (owner != null)
        {
            var result = await win.ShowDialog<bool>(owner);
            if (result)
                LoadData();
        }
    }

    private async void UsersDataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (UsersDataGrid.SelectedItem is User user)
        {
            var win = new UserEditWindow(user);
            var owner = this.VisualRoot as Window;
            if (owner != null)
            {
                var result = await win.ShowDialog<bool>(owner);
                if (result)
                    LoadData();
            }
        }
    }

    private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (UsersDataGrid.SelectedItem is User user)
        {
            App.dbContext.Users.Remove(user);
            App.dbContext.SaveChanges();
            LoadData();
        }
    }
}