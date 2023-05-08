using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using StorehouseOfAppliances.Models;

namespace StorehouseOfAppliances.Pages
{

    public partial class LoginPage : Page
    {
        public string Password { get; set; }

        public string Login { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            GridMain.DataContext = this;
        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.Context.Users.FirstOrDefault(item => item.Login == Login && item.Password == EncodePassword(Password));

            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Login))
            {
                ShowErrorMessage("Введи логин или пароль!");
                return;
            }

            if (currentUser != null)
            {
                App.CurrentUser = currentUser;
                NavigationService.Navigate(new MenuPage());
            }
            else
            {
                ShowErrorMessage("Пользователь с такими данными не найден!");
            }
        }

        private string EncodePassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = ((PasswordBox)sender).Password;
        }

    }
}
