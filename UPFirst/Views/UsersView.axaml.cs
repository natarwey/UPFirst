using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using UPFirst.Data;

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
}