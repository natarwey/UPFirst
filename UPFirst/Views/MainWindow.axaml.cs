using Avalonia.Controls;
using Avalonia.Data;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPFirst.Data;

namespace UPFirst.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new ItemsView();
        }

        private async void ItemButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new ItemsView();
        }

        private async void UsersButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new UsersView();

        }

        private async void BasketButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new BasketsView();

        }

    }
}