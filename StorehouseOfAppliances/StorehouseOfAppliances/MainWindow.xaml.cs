using System;
using StorehouseOfAppliances.Pages;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Azure;

namespace StorehouseOfAppliances
{
    public partial class MainWindow : Window
    {
        bool MainWindowState = false; //Статус размера окна

        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new LoginPage());
            GridMain.DataContext = this;
        }

        private void CloseWindowButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void WrapScreenButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void FullScreenButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (!MainWindowState)
            {
                this.WindowState = WindowState.Maximized;
                MainWindowState = true;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                MainWindowState = false;
            }
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект LoginPage
            LoginPage loginPage = new LoginPage();

            // Устанавливаем содержимое Frame в LoginPage
            MainFrame.Content = loginPage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Проверяем, является ли текущая страница страницей LoginPage
            if (MainFrame.Content is LoginPage)
            {
                // Скрываем кнопку Exit
                ExitButton.Visibility = Visibility.Hidden;
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // Проверяем, является ли новая страница страницей LoginPage
            if (e.Content is LoginPage)
            {
                // Скрываем кнопку Exit
                ExitButton.Visibility = Visibility.Hidden;
            }
            else
            {
                // Показываем кнопку Exit
                ExitButton.Visibility = Visibility.Visible;
            }
        }
    }
}
