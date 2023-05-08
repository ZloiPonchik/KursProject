using StorehouseOfAppliances.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using StorehouseOfAppliances.Models.AdditionalEntities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace StorehouseOfAppliances.Pages
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private ObservableCollection<UserData> _users;

        public ObservableCollection<UserData> Users1
        { 
            get { return _users; }
            set 
            {
                _users = value;
            }
        }

        public UsersPage()
        {
            InitializeComponent();
            _users = new ObservableCollection<UserData>(GetData());
            DataContext = this;
        }
        private void ButtonGoBackMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage(null));
        }



        private void ButtonDeleteDataTable_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя для удаления.");
                return;
            }

            var user = (UserData)UsersGrid.SelectedItem;

            MessageBoxResult messageBoxResult = MessageBox.Show($"Вы действительно хотите удалить пользователя {user.Login}?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using (var context = new StorehouseOfAppliancesContext())
                {
                    var userToDelete = context.Users.FirstOrDefault(u => u.Login == user.Login);
                    if (userToDelete != null)
                    {
                        context.Users.Remove(userToDelete);
                        context.SaveChanges();
                        _users.Remove(user);
                        MessageBox.Show($"Пользователь {user.Login} удален.");
                    }
                }
            }
        }

        private void ButtonEditDataTable_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя для редактирования.");
                return;
            }

            var userData = (UserData)UsersGrid.SelectedItem;

            using (var context = new StorehouseOfAppliancesContext())
            {
                NavigationService.Navigate(new DataUserPage(userData.Login, context.Users.FirstOrDefault(u => u.Login == userData.Login)));
            }


        }

        private List<UserData> GetData()
        {
            using (var context = new StorehouseOfAppliancesContext())
            {
                var userData = from user in context.Users
                            join role in context.Roles on user.RoleId equals role.Id
                            select new UserData
                            {
                                Login = user.Login,
                                RoleName = role.Name,
                                LastName = user.LastName,
                                FirstName = user.FirstName,
                                Patronymic = user.Patronymic,
                                TelephoneNumber = user.TelephoneNumber,
                                Image = user.Image
                            };

                return userData.ToList();
            }
        }
    }
}
