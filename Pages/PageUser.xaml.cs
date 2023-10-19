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
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        public PageUser()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrProd.ItemsSource = DbConnect.entObj.Concert.ToList();
            }
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Concert.Count(x => x.Name == TxbName.Text) > 0)
            {
                MessageBox.Show("Вы оформили заказ билетов, ожидайте.",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Такого концерта не существует.",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
