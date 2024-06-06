using ListBookDemo.BL;
using System.Windows;


namespace ListBookDemo.MyWPF.Forms
{
    /// <summary>
    /// Логика взаимодействия для ListVacanciesWindow.xaml
    /// </summary>
    public partial class ListVacanciesWindow : Window
    {
        JobService service = new JobService();
        public ListVacanciesWindow()
        {
            InitializeComponent();
            listVacancies.ItemsSource = service.jobs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string select = listVacancies.SelectedValue as string;
                if (select != null)
                {
                    JobType enm = (JobType)Enum.Parse(typeof(JobType), select);
                    service.Get_a_job(App.User, enm, (x) => MessageBox.Show(x));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
