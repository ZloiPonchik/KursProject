using StorehouseOfAppliances.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MessageBox = System.Windows.MessageBox;

namespace StorehouseOfAppliances.Pages
{
    // Класс AddPalletPage представляет страницу для добавления новых паллетов в базу данных.
    public partial class AddPalletPage : Page
    {
        // Свойствo Pallet используются для получения доступа к типу доступа и экземпляру паллеты.
        public Pallet Pallet { get; set; } = new Pallet();


        public AddPalletPage(Pallet? pallet = null)
        {
            InitializeComponent();
            GridMain.DataContext = this;

        }


        // Метод ButtonAddNewPallet_Click выполняет проверку ошибок и добавление нового паллета в базу данных при нажатии кнопки "Добавить".
        private void ButtonAddNePallet_Click(object sender, RoutedEventArgs e)
        {
            string message = CheckErrors();

            if (string.IsNullOrEmpty(message))
            {
                try
                {
                    Pallet pallet = new Pallet()
                    {
                        Weight = Pallet.Weight,
                        Height = Pallet.Height,
                        Length = Pallet.Length,
                        Width = Pallet.Width
                    };

                    App.Context.Pallets.Add(Pallet);
                    App.Context.SaveChanges();
                    MessageBox.Show("Паллет добавлет", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new PalletsPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ShowErrorMessage(message);
            }

        }

        // Метод ShowErrorMessage отображает сообщение об ошибке.
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Метод CheckErrors проверяет наличие ошибок в введенных значениях.
        private string CheckErrors()
        {
            string errorMessage = "";

            if (Pallet.Width <= 0)
            {
                errorMessage += "Введите ширину больше 0!\n";
            }

            if (Pallet.Height <= 0)
            {
                errorMessage += "Введите высоту больше 0!\n";
            }

            if (Pallet.Length <= 0)
            {
                errorMessage += "Введите длинну больше 0!\n";
            }

            if (Pallet.Weight <= 0)
            {
                errorMessage += "Введите вес больше 0!\n";
            }

            return errorMessage;


        }

        // Методы ButtonGoBackMenu_Click и ButtonCancel_Click
        // выполняют навигацию на другие страницы при нажатии соответствующих кнопок.
        private void ButtonGoBackMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());

        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PalletsPage());

        }
    }
}
