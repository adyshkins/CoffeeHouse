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
using Microsoft.Win32;
using System.IO;

using CoffeeHouse.ClassHelper;
using CoffeeHouse.DB;
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {

        private string pathPhoto = null;
        public AddEditProductWindow()
        {
            InitializeComponent();

            CmbCategory.ItemsSource = Context.Category.ToList();
            CmbCategory.DisplayMemberPath = "Title";
            CmbCategory.SelectedIndex = 0;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathPhoto = openFileDialog.FileName;

            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Stuff stuff = new Stuff();
            
            stuff.Title = TbName.Text;
            stuff.Price = Convert.ToDecimal(TbPrice.Text);
            stuff.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
            stuff.Photo = File.ReadAllBytes(pathPhoto);
            stuff.Count = 0;
            stuff.ExpirationDate = Convert.ToInt32(TbExpirationDate.Text);

            Context.Stuff.Add(stuff);
            Context.SaveChanges();
            MessageBox.Show("Товар добавлен");
            this.Close();


        }
    }
}
