using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CoffeeHouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetListProduct();
        }

        private void GetListProduct()
        {
            ObservableCollection<DB.Stuff> stuffs = new ObservableCollection<DB.Stuff>(ClassHelper.CartClass.Stuffs);

            LvCartProductList.ItemsSource = stuffs;
        }

        private void BtnRemoveToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            var selectedProduct = button.DataContext as DB.Stuff;


            if (selectedProduct != null)
            {
                ClassHelper.CartClass.Stuffs.Remove(selectedProduct);
            }
            GetListProduct();


        }
    }
}
