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
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            CmbGender.ItemsSource = Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "Gender1";

        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            // валидация 
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }

            //Int32.TryParse(TbPhone.Text, out _);

            // проверка на уникальность 
            var authUser = Context.Guest.ToList()
                .Where(i => i.Login == TbLogin.Text).FirstOrDefault();                

            if (authUser != null)
            {
                MessageBox.Show("логин занят");
                return ;
            }

            // добавление в БД

            DB.Guest guest = new DB.Guest();
            guest.DiscountCode = "1";
            guest.Name = TbName.Text;
            guest.IDGender = (CmbGender.SelectedItem as DB.Gender).IDGender;
            guest.Email = TbEmail.Text;
            guest.Birthday = DPBirthday.SelectedDate.Value;
            guest.IDLevelDiscount = 1;
            guest.Password = PbPassword.Password;
            guest.Login = TbLogin.Text;
            guest.Score = 0;
            guest.Phone = TbPhone.Text;
            

            Context.Guest.Add(guest);

            Context.SaveChanges();

            MessageBox.Show("OK");
        }
    }
}

////
////
////
////
////
////////
////
////