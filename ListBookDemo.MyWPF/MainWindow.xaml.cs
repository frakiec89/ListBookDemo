using System.Windows;

namespace ListBookDemo.MyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}