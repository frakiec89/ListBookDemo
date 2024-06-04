using ListBookDemo.BL;
using ListBookDemo.DB.Model;
using ListBookDemo.DB.Services;
using System.Windows;
using System.Windows.Controls;

namespace ListBookDemo.MyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ServiceBook _service;
        GameLogic _gameLogic;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
             _service = new ServiceBook();
             _gameLogic = new GameLogic(App.User);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gridUser.DataContext = App.User;   
        }

        private void btnLibrary_Click(object sender, RoutedEventArgs e)
        {
            Forms.WindowBookLibrary window = new Forms.WindowBookLibrary();
            window.ShowDialog();
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Forms.BooksWindow booksWindow = new Forms.BooksWindow();
            booksWindow.ShowDialog();
        }

        private void Button_Click_NextStatus(object sender, RoutedEventArgs e)
        {
            StatusType type; 
            var b = e.Source as Button;
            if (b != null)
            {
                try
                {
                    switch (b.Name)
                    {
                        case "btnJun": type = StatusType.Junior; break;
                        case "btnMidle": type = StatusType.Middle; break;
                        default:
                            type = StatusType.No;
                            MessageBox.Show("No"); // todo реализовать  отдельный интерфейс 
                            break;
                    }
                    _gameLogic.NetxStatus(type, x => MessageBox.Show(x));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            gridUser.DataContext = null;
            gridUser.DataContext = App.User;
        }

        private void TEMPFARM_Click(object sender, RoutedEventArgs e)
        {
            App.User.Experience += 200;
            gridUser.DataContext = null;
            gridUser.DataContext = App.User;
        }
    }
}