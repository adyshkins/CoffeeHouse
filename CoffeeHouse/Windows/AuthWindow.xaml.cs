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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // 1. Получить всю таблицу Гость
            // 2. Выбрать нужные данный(логин и пароль)
            // 3. Получить одну запись

            var authUser = Context.Emploee.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password)
                .FirstOrDefault();

            if (authUser != null)
            {
                // сохраняем пользователя в системе 
                ClassHelper.UserDataClass.Emploee = authUser;

                // переходим на главную страницу
                MainWindow mainWindow = new MainWindow();   
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
            
        }
    }
}
