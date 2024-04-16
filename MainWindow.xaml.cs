using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac18
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInDataGrid();
        }
        void LoadDBInDataGrid()
        {
            using (Devyatkinv11pr18Context _db = new Devyatkinv11pr18Context())
            {
                if (tbIndex.Text == "1")
                {
                    nTable.Content = "Таблица №1";
                    btnLeft.Visibility = Visibility.Collapsed;
                }
                if (tbIndex.Text == "3")
                {
                    nTable.Content = "Таблица №3";
                    btnRight.Visibility = Visibility.Collapsed;
                }
                if (tbIndex.Text == "2")
                {
                    nTable.Content = "Таблица №3";
                    btnLeft.Visibility = Visibility.Visible;
                    btnRight.Visibility = Visibility.Visible;
                }
                
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(tbIndex.Text);
            n += 1;
            tbIndex.Text = n.ToString();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(tbIndex.Text);
            n -= 1;
            tbIndex.Text = n.ToString();
        }
    }
}