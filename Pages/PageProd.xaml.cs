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
    /// Логика взаимодействия для PageProd.xaml
    /// </summary>
    public partial class PageProd : Page
    {
        public PageProd()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Concert.Count(x => x.Name == TxbName.Text) > 0)
            {
                MessageBox.Show("Такой концерт уже есть",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    Concert concertObj = new Concert()
                    {
                        Name = TxbName.Text,
                        Price = Convert.ToInt32(TxbPrice.Text),
                        Date = Convert.ToDateTime(TxbDate.Text)
                    };
                    DbConnect.entObj.Concert.Add(concertObj);
                    DbConnect.entObj.SaveChanges();
                    MessageBox.Show("Концерт создан",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Критический сбой работы приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrProd.ItemsSource = DbConnect.entObj.Concert.ToList();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var DocForRemoving = DgrProd.SelectedItems.Cast<Concert>().ToList();
            try
            {
                DbConnect.entObj.Concert.RemoveRange(DocForRemoving);
                DbConnect.entObj.SaveChanges();
                MessageBox.Show("Данные удалены.");
                DgrProd.ItemsSource = DbConnect.entObj.Concert.ToList();
            } catch (Exception ex)
            {
                MessageBox.Show("Подтвердите удаление " + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrProd.ItemsSource = DbConnect.entObj.Concert.ToList();
            }
        }

        
    }
}
