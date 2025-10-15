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
        //private string _currentTable = "items";

        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new ItemsView();
        }

        private async void ItemButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new ItemsView();
            //MainDataGrid.Columns.Clear();
            //MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
            //_currentTable = "items";
        }

        private async void UsersButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new UsersView();
            //MainDataGrid.Columns.Clear();
            //MainDataGrid.ItemsSource = App.dbContext.Users.ToList();
            //_currentTable = "users";
        }

    }
}