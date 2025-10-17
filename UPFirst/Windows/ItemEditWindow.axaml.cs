using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UPFirst.Data;

namespace UPFirst.Views;

public partial class ItemEditWindow : Window
{
    private readonly Item _item;

    public ItemEditWindow()
    {
        InitializeComponent();
        _item = new Item();
        DataContext = _item;
    }

    public ItemEditWindow(Item item) : this()
    {
        _item = item;
        DataContext = _item;
    }

    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_item.Title))
        {
            return;
        }

        if (!decimal.TryParse(_item.Price.ToString(), out _))
        {
            return;
        }

        var db = App.dbContext;
        if (_item.Id == 0)
            db.Items.Add(_item);
        else 
            db.Items.Update(_item);

            db.SaveChanges();

        Close(true);
    }

    private void CancelButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(false);
    }
}