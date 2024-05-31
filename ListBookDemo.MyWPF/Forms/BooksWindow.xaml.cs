using ListBookDemo.DB;
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
        public BooksWindow()
        {
            InitializeComponent();
            _service = new ServiceBook();

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
                        _service.BookHistoriesAdd(App.User.UserId, book.BookId);
                        MessageBox.Show("Книга куплена");
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
