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

using CoffeeHouse.ClassHelper;
using CoffeeHouse.DB;
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();

            // проверка роли

            if (ClassHelper.UserDataClass.Emploee.IDPost != 1)
            {
                BtnAddProduct.Visibility = Visibility.Collapsed;
            }
            GetProducr();
        }

        private void GetProducr()
        {
            List<Stuff> stuffList = new List<Stuff>();

            stuffList = Context.Stuff.ToList();

            LvProductList.ItemsSource = stuffList;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProductWindow addEditProductWindow = new AddEditProductWindow();
            this.Hide();
            addEditProductWindow.ShowDialog();
            this.Show();
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            var selectedProduct = button.DataContext as DB.Stuff;


            if (selectedProduct != null) 
            {
                ClassHelper.CartClass.Stuffs.Add(selectedProduct);
            }


        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.Show();
        }
    }
}
