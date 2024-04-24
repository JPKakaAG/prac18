using Microsoft.EntityFrameworkCore;
using prac18.models;
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
                int selectedIndex = dg1.SelectedIndex;
                _db.Veterans.Load();
                dg1.ItemsSource = _db.Veterans.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == dg1.Items.Count) selectedIndex--;
                    dg1.SelectedIndex = selectedIndex;
                    dg1.ScrollIntoView(dg1.SelectedItem);
                }
                dg1.Focus();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.devyatkinVeteran = null;
            AddEdit f = new AddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Data.devyatkinVeteran = (Veteran)dg1.SelectedItem;
                AddEdit f = new AddEdit();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInDataGrid();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Veteran row =(Veteran)dg1.SelectedItem;
                    if (row != null)
                    {
                        using (Devyatkinv11pr18Context _db = new Devyatkinv11pr18Context())
                        {
                            _db.Veterans.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBInDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else dg1.Focus();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItems != null)
            {
                Data.devyatkinVeteran = (Veteran)dg1.SelectedItem;
                AddEdit ar = new AddEdit();
                ar.tbAge.IsEnabled = false;
                ar.tbAgeGroup.IsEnabled = false;
                ar.tbApartment.IsEnabled = false;
                ar.tbF.IsEnabled = false;
                ar.tbN.IsEnabled = false;
                ar.tbO.IsEnabled = false;
                ar.WindowAddEdit.Title = "Просмотр записи";
                ar.btnAddEdit.IsEnabled = false;
                ar.ShowDialog();
                LoadDBInDataGrid();
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnViborka_Click(object sender, RoutedEventArgs e)
        {
            using (Devyatkinv11pr18Context _db = new Devyatkinv11pr18Context()) 
            {
                if (rdv1.IsChecked == true)
                {
                    var women = from Veteran in _db.Veterans where Veteran.Фамилия.EndsWith("а") select Veteran;
                    dg1.ItemsSource = women.ToList();
                    MessageBox.Show("Были выбраны только девушки");
                }
                else if (rdv2.IsChecked == true) 
                {
                    var age = from Veteran in _db.Veterans where Veteran.Возраст > 20 select Veteran;
                    dg1.ItemsSource = age.ToList();
                    MessageBox.Show("Были выбраны те кто старше 20 лет");
                }
                else if (rdv3.IsChecked == true)
                {
                    var age = from Veteran in _db.Veterans where Veteran.Имя.StartsWith("В") select Veteran;
                    dg1.ItemsSource = age.ToList();
                    MessageBox.Show("Были выбраны те чьё имя начинается на 'В' ");
                }
                else if (rdv4.IsChecked == true)
                {
                    var age = from Veteran in _db.Veterans where Veteran.НомерКомнаты <= 100 && Veteran.НомерКомнаты >= 1 select Veteran;
                    dg1.ItemsSource = age.ToList();
                    MessageBox.Show("Были выбраны те кто живёт с 1 по 100 комнату ");
                }
                else if (rdv5.IsChecked == true)
                {
                    var age = from Veteran in _db.Veterans where Veteran.ВозрастнуюГруппа.StartsWith("Ю") && Veteran.ВозрастнуюГруппа.EndsWith("р")  select Veteran;
                    dg1.ItemsSource = age.ToList();
                    MessageBox.Show("Были выбраны только юниоры");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (Devyatkinv11pr18Context _db = new Devyatkinv11pr18Context()) 
            { 
                if (rdo1.IsChecked == true) 
                {
                    
                }
            }
        }
    }
}