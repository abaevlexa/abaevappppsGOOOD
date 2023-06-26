﻿using abaevapppps.DB;
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
            if (DbConnect.entObj.Products.Count(x => x.Name == TxbName.Text) > 0)
            {
                MessageBox.Show("Такой продукт уже есть",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    Products prodObj = new Products()
                    {
                        Name = TxbName.Text,
                        Price = Convert.ToInt32(TxbPrice.Text)
                    };
                    DbConnect.entObj.Products.Add(prodObj);
                    DbConnect.entObj.SaveChanges();
                    MessageBox.Show("Продукт создан",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Критический сбой работы приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
