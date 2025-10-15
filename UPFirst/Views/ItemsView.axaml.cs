using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using UPFirst.Data;

namespace UPFirst.Views;

public partial class ItemsView : UserControl
{
    public ItemsView()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        ItemsDataGrid.ItemsSource = App.dbContext.Items.ToList();
    }

    //private async void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    var win = new ItemEditWindow();
    //    var result = await win.ShowDialog<bool>(this.FindAncestor<Window>());
    //    if (result)
    //        LoadData();
    //}

    //private async void ItemsDataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    //{
    //    if (ItemsDataGrid.SelectedItem is Item item)
    //    {
    //        var win = new ItemEditWindow(item);
    //        var result = await win.ShowDialog<bool>(this.FindAncestor<Window>());
    //        if (result)
    //            LoadData();
    //    }
    //}

    //private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    if (ItemsDataGrid.SelectedItem is Item item)
    //    {
    //        App.dbContext.Items.Remove(item);
    //        App.dbContext.SaveChanges();
    //        LoadData();
    //    }
    //}
}