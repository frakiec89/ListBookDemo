using ListBookDemo.BL;
using ListBookDemo.DB;
using ListBookDemo.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;
using System.Windows.Controls;


namespace ListBookDemo.MyWPF.Forms
{
    /// <summary>
    /// Логика взаимодействия для BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {

        ServiceBook _service;
        GameLogic _gameLogic;

        public BooksWindow()
        {
            InitializeComponent();
            _service = new ServiceBook();
            _gameLogic = new GameLogic(App.User);
            listBook.ItemsSource = _service.Books;

        }

    

        private void btnBuyBook_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                var book = b.DataContext as Book;
                if (book != null)
                {
                    try
                    {
                        _gameLogic.BayBook(book, (x) => MessageBox.Show(x)); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
