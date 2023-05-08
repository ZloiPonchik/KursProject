using StorehouseOfAppliances.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MessageBox = System.Windows.MessageBox;



namespace StorehouseOfAppliances.Pages
{
    // Класс AddProductPage представляет страницу для добавления новых товаров в базу данных.
    public partial class AddProductPage : Page
    {
        // Свойствo product используются для получения доступа к типу доступа и экземпляру товара.
        public Product Product { get; set; } = new Product();

        public AddProductPage(Product? product = null)
        {
            InitializeComponent();

            GridMain.DataContext = this;

        }

        // Метод ButtonAddNewProduct_Click выполняет проверку ошибок и добавление нового товара в базу данных при нажатии кнопки "Добавить".
        private void ButtonAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            string message = CheckErrors();

            if (string.IsNullOrEmpty(message))
            {
                try
                {
                    Product product = new Product()
                    {
                        Name = Product.Name,
                        Supplier = Product.Supplier,
                        Volume = Product.Volume,
                        Weight = Product.Weight,
                        Quantity = Product.Quantity,
                    };

                    App.Context.Products.Add(Product);
                    App.Context.SaveChanges();
                    MessageBox.Show("Товар добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new ProductsPage());
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

            if (string.IsNullOrEmpty(Product.Name))
            {
                errorMessage += "Введите название товара!\n";
            }

            if (string.IsNullOrEmpty(Product.Supplier))
            {
                errorMessage += "Введите название товара!\n";
            }

            if (Product.Weight <= 0)
            {
                errorMessage += "Введите вес больше 0!\n";
            }

            if (Product.Volume <= 0)
            {
                errorMessage += "Введите объем больше 0!\n";
            }

            if (Product.Quantity <= 0)
            {
                errorMessage += "Введите колличество больше 0!\n";
            }


            return errorMessage;


        }

        // Методы ButtonGoBackMenu_Click и ButtonCancel_Click
        // выполняют навигацию на другие страницы при нажатии соответствующих кнопок.
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }
        private void ButtonGoBackMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }
}
