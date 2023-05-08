using StorehouseOfAppliances.Models;
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

namespace StorehouseOfAppliances.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();        
        }

        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser.RoleId == 1)
            {
                NavigationService.Navigate(new UsersPage());

            }
            else
            {
                MessageBox.Show("Доступ к пользователям есть только у Администратора!");

            }
        }

        private void ButtonPallet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PalletsPage());
        }

        private void ButtonProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());

        } 
    }
}
