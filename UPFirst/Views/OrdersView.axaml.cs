using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UPFirst.Data;

namespace UPFirst.Views;

public partial class OrdersView : UserControl
{
    public OrdersView()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        OrdersDataGrid.ItemsSource = App.dbContext.Orders.Where(x => x.UserId == CurrentUser.currentUser.Id).Include(x => x.User).ToList();
    }

}