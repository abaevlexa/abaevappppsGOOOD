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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace abaevapppps.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddDetail.xaml
    /// </summary>
    public partial class PageAddDetail : Page
    {
        public PageAddDetail()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker userObj = new Worker()
                {
                    Name = TxbTitle.Text,
                    Date = Convert.ToDateTime(TxbDate.Text),
                    Salary = Convert.ToInt32(TxbCost.Text),
                    Image = TxbImage.Text,
                    IdWorkerType = Convert.ToInt32(TxbDetailId.Text)
                };
                DbConnect.entObj.Workers.Add(userObj);
                DbConnect.entObj.SaveChanges();

                MessageBox.Show("Сотрудник добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Критический сбой работы приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

