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
        private List<Worker> allItems;
        public PageProd()
        {
            InitializeComponent();
            allItems = DbConnect.entObj.Workers.ToList();
            MaterialList.ItemsSource = allItems.ToList();
        }


        private void BtnNext_Copy_Click(object sender, RoutedEventArgs e)
        {
            AddMaterial addMaterial = new AddMaterial();
            addMaterial.Show();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaterialList.ItemsSource = DB.DbConnect.entObj.Workers.Where(x => x.Name.Contains(TxbSearch.Text)).Take(15).ToList();
                ResultTxb.Text = MaterialList.Items.Count + "/" + DB.DbConnect.entObj.Workers.Where(x => x.Name.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MaterialList.ItemsSource = allItems.ToList();
            try
            {
                CmbFilter.ItemsSource = DB.DbConnect.entObj.WorkerTypes.ToList();
                CmbFilter.DisplayMemberPath = "Name";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;
               
                MaterialList.ItemsSource = DB.DbConnect.entObj.Workers.ToList();
                ResultTxb.Text = MaterialList.Items.Count + "/" + DB.DbConnect.entObj.Workers.Count().ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSort.SelectedIndex == 0)
            {
                List<Worker> sortMaterials = allItems.OrderBy(x => x.Name).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<Worker> sortMaterials = allItems.OrderByDescending(x => x.Name).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 2)
            {
                List<Worker> sortMaterials = allItems.OrderBy(x => x.Salary).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 3)
            {
                List<Worker> sortMaterials = allItems.OrderByDescending(x => x.Salary).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 4)
            {
                List<Worker> sortMaterials = allItems.OrderBy(x => x.Date).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 5)
            {
                List<Worker> sortMaterials = allItems.OrderByDescending(x => x.Date).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            if (CmbSort.SelectedIndex == 0)
            {
                List<Detail> sortMaterials = allItems.OrderBy(x => x.IdDetailType).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<Detail> sortMaterials = allItems.OrderByDescending(x => x.IdDetailType).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 2)
            {
                List<Detail> sortMaterials = allItems.OrderBy(x => x.IdDetailType).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            */
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
                  
        }
    }
}
