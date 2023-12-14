using abaevapppps.DB;
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

namespace abaevapppps.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddMaterial : Window
    {
        public AddMaterial()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Detail userObj = new Detail()
                {
                    Name = TxbTitle.Text,
                    Date = Convert.ToDateTime(TxbDate.Text),
                    Price = Convert.ToInt32(TxbCost.Text),
                    Image = TxbImage.Text,
                    IdDetailType = Convert.ToInt32(TxbDetailId.Text)
                };
                DbConnect.entObj.Detail.Add(userObj);
                DbConnect.entObj.SaveChanges();

                MessageBox.Show("Материал добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Критический сбой работы приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
