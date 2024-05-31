using ListBookDemo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListBookDemo.MyWPF.Forms
{
    /// <summary>
    /// Логика взаимодействия для WindowBookLibrary.xaml
    /// </summary>
    public partial class WindowBookLibrary : Window
    {

        ServiceBook _service;
        public WindowBookLibrary()
        {
            InitializeComponent();
            _service = new ServiceBook();
            listBook.ItemsSource = _service.BooksUser(App.User.UserId);
        }
    }
}
