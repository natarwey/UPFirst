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

public partial class ItemsView : UserControl
{
    private readonly ObservableCollection<Item> _itemsCollection;
    public ItemsView()
    {
        InitializeComponent();

        _itemsCollection = new ObservableCollection<Item>();
        ItemsDataGrid.ItemsSource = _itemsCollection;
        this.Loaded += async (s, e) => await LoadItemsAsync();
    }

    private async Task LoadItemsAsync()
    {
        _itemsCollection.Clear();
        var context = App.dbContext;
        var items = await context.Items.AsNoTracking().OrderBy(item => item.Id).ToListAsync();
        foreach (var item in items)
        {
            _itemsCollection.Add(item);
        }
    }

    private async void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var win = new ItemEditWindow();
        var owner = this.VisualRoot as Window;
        
        var result = await win.ShowDialog<bool>(owner);
        LoadItemsAsync();
    }

    private async void ItemsDataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (ItemsDataGrid.SelectedItem is Item item)
        {
            var win = new ItemEditWindow(item);
            var owner = this.VisualRoot as Window;
            
            var result = await win.ShowDialog<bool>(owner);
            LoadItemsAsync();
        }
    }

    private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ItemsDataGrid.SelectedItem is Item item)    
        {
            App.dbContext.Items.Remove(item);
            App.dbContext.SaveChanges();
            LoadItemsAsync();
        }
    }

    private void InBasketButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ItemsDataGrid.SelectedItem is Item selectedItem)
        {
            var existing = App.dbContext.Baskets.FirstOrDefault(b => b.ItemId == selectedItem.Id);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                App.dbContext.Baskets.Add(new Basket
                {
                    ItemId = selectedItem.Id,
                    UserId = CurrentUser.currentUser.Id,
                    Quantity = 1
                });
            }

            App.dbContext.SaveChanges();
        }
    }
}