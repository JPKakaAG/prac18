using prac18.models;
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

namespace prac18
{
    /// <summary>
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        public AddEdit()
        {
            InitializeComponent();
        }
        Devyatkinv11pr18Context _db = new Devyatkinv11pr18Context();
        Veteran _Devyatkin;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.devyatkinVeteran == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить";
                _Devyatkin = new Veteran();
            }
            else
            {
                WindowAddEdit.Title = "Измененик записи";
                btnAddEdit.Content = "Изменить";
                _Devyatkin = _db.Veterans.Find(Data.devyatkinVeteran.Id);
            }
            WindowAddEdit.DataContext = _Devyatkin;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbF.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (tbN.Text.Length == 0) errors.AppendLine("Введите имя");
            if (tbO.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (tbApartment.Text.Length == 0) errors.AppendLine("Введите номер комнаты");
            if (tbAge.Text.Length == 0) errors.AppendLine("Введите возраст");
            if (tbAgeGroup.Text.Length == 0) errors.AppendLine("Введите возрасстную группу");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                if (Data.devyatkinVeteran == null)
                {
                    _db.Veterans.Add(_Devyatkin);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
