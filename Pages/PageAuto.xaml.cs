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
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        public PageAuto()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = DbConnect.entObj.Users.FirstOrDefault(x =>
                x.Name == TxbLog.Text && x.Password == TxbPas.Text);

                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет", "Ошибка Авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    Uri uri = new Uri("/Pages/PageReg.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
                else if (userObj.IdRole == 1)
                {
                    
                            MessageBox.Show("Здравствуйте , " + userObj.Name + " !", "Уведомление",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                            Uri uri = new Uri("/Pages/PageProd.xaml", UriKind.Relative);
                            this.NavigationService.Navigate(uri);

                }
                else
                {
                    MessageBox.Show("Здравствуйте , " + userObj.Name + " !", "Уведомление",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    Uri uri = new Uri("/Pages/PageUser.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString(), "Критическая работа приложения",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/Pages/PageReg.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
