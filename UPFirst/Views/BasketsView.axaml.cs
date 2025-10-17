using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UPFirst.Data;

namespace UPFirst.Views;

public partial class BasketsView : UserControl
{
    public BasketsView()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        BasketsDataGrid.ItemsSource = App.dbContext.Baskets.Where(x => x.UserId == CurrentUser.currentUser.Id).Include(x => x.Item).Include(x => x.User).ToList();
    }

    private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (BasketsDataGrid.SelectedItem is Basket basket)
        {
            App.dbContext.Baskets.Remove(basket);
            App.dbContext.SaveChanges();
            LoadData();
        }
    }
}