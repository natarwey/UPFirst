using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UPFirst.Data;

namespace UPFirst.Views;

public partial class BasketsView : UserControl
{
    public BasketsView()
    {
        InitializeComponent();
        LoadData();

        UpdateButtonsVisibility();
    }

    private void UpdateButtonsVisibility()
    {
        DeleteButton.IsVisible = CurrentUser.CanDeleteFromBasket;
        BuyButton.IsVisible = CurrentUser.CanBuy;
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

    private void BuyButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var userId = CurrentUser.currentUser.Id;

        var basketItems = App.dbContext.Baskets
            .Where(b => b.UserId == userId)
            .Include(b => b.Item)
            .ToList();

        if (!basketItems.Any())
            return;

        var total = basketItems.Sum(b => b.Item.Price * b.Quantity);

        var order = new Order
        {
            UserId = userId,
            Data = DateTime.Now,
            PriceTotal = total
        };

        App.dbContext.Orders.Add(order);
        App.dbContext.SaveChanges();

        App.dbContext.Baskets.RemoveRange(basketItems);
        App.dbContext.SaveChanges();

        LoadData();
    }
}