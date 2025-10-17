using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UPFirst.Data;
using UPFirst.Views;

namespace UPFirst.Views;

public partial class UsersView : UserControl
{
    private readonly ObservableCollection<User> _usersCollection;
    public UsersView()
    {
        InitializeComponent();

        _usersCollection = new ObservableCollection<User>();
        UsersDataGrid.ItemsSource = _usersCollection;
        this.Loaded += async (s, e) => await LoadUsersAsync();

        UpdateButtonsVisibility();
    }

    private void UpdateButtonsVisibility()
    {
        AddButton.IsVisible = CurrentUser.CanManageUsers;
        DeleteButton.IsVisible = CurrentUser.CanManageUsers;
    }

    private async Task LoadUsersAsync()
    {
        _usersCollection.Clear();
        var context = App.dbContext;
        var users = await context.Users.AsNoTracking().OrderBy(user => user.Id).ToListAsync();
        foreach (var user in users)
        {
            _usersCollection.Add(user);
        }
    }

    private async void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var win = new UserEditWindow();
        var owner = this.VisualRoot as Window;
        
        var result = await win.ShowDialog<bool>(owner);
        LoadUsersAsync();
    }

    private async void UsersDataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (!CurrentUser.CanManageItems)
            return;

        if (UsersDataGrid.SelectedItem is User user)
        {
            var win = new UserEditWindow(user);
            var owner = this.VisualRoot as Window;
            
            var result = await win.ShowDialog<bool>(owner);
            LoadUsersAsync();
        }
    }

    private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (UsersDataGrid.SelectedItem is User user)
        {
            App.dbContext.Users.Remove(user);
            App.dbContext.SaveChanges();
            LoadUsersAsync();
        }
    }
}