using StorehouseOfAppliances.Models.AdditionalEntities;
using StorehouseOfAppliances.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection.Metadata;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;
using Microsoft.Win32;
using System;

namespace StorehouseOfAppliances.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private ObservableCollection<ProductData> _products;

        public ObservableCollection<ProductData> Products1
        {
            get { return _products; }
            set
            {
                _products = value;
            }
        }
        public ProductsPage()
        {
            InitializeComponent();
            _products = new ObservableCollection<ProductData>(GetData());
            DataContext = this;
        }

        private void ButtonGoBackMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage(null));
        }

        private List<ProductData> GetData()
        {
            using (var context = new StorehouseOfAppliancesContext())
            {
                var productData = from product in context.Products

                                  select new ProductData
                                  {
                                      Id = product.Id,
                                      Name = product.Name,
                                      Supplier = product.Supplier,
                                      Volume = product.Volume,
                                      Weigth = product.Weight,
                                      Quantity = product.Quantity,
                                  };

                return productData.ToList();
            }
        }
        private void ButtonDeleteDataTable_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар для удаления.");
                return;
            }

            var product = (ProductData)ProductGrid.SelectedItem;

            MessageBoxResult messageBoxResult = MessageBox.Show($"Вы действительно хотите удалить паллет {product.Name}?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using (var context = new StorehouseOfAppliancesContext())
                {
                    var productToDelete = context.Products.FirstOrDefault(u => u.Id == product.Id);
                    if (productToDelete != null)
                    {
                        context.Products.Remove(productToDelete);
                        context.SaveChanges();
                        _products.Remove(product);
                        MessageBox.Show($"Товар {product.Name} удален.");
                    }
                }
            }
        }

        private void ButtonSaveInPDF_Click(object sender, RoutedEventArgs e)
        {
            // Путь к шрифту.
            string fontPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");

            // Параметры шрифтов
            BaseFont headFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font headerFont = new Font(headFont, 12f, Font.BOLD);
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); 
            Font font = new Font(baseFont, 12f, Font.NORMAL);

            // Создаем диалоговое окно выбора файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF файл (*.pdf)|*.pdf";
            saveFileDialog.Title = "Сохранить PDF файл";
            saveFileDialog.ShowDialog();

            // Если пользователь выбрал файл, то сохраняем в него данные
            if (saveFileDialog.FileName != "")
            {
                // Открываем документ
                iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                document.Open();


                // Получаем данные из DataGrid
                List<ProductData> data = new List<ProductData>();
                foreach (var item in ProductGrid.Items)
                {
                    ProductData? product = item as ProductData;
                    if (product != null)
                    {
                        data.Add(product);
                    }
                }

                // Фиксированное количество столбцов в таблице
                const int COLUMN_COUNT = 6;

                // Создаем таблицу с фиксированным количеством столбцов
                PdfPTable table = new PdfPTable(COLUMN_COUNT);
              

                // Задаем ширину столбцов
                float[] columnWidths = new float[] { 1f, 3f, 2f, 2f, 2f, 2f };
                table.SetWidths(columnWidths);

                // Добавляем заголовки таблицы
                table.AddCell(new PdfPCell(new Phrase("№", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Наименование", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Поставщик", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Объем (М³)", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Вес (Кг)", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Количество", headerFont)));
                
                // Добавляем данные из DataGrid в PDF-документ
                foreach (var item in data)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.Id.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Name, font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Supplier, font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Volume.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Weigth.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Quantity.ToString(), font)));
                }

                document.Add(table);
                document.Close();
            }
        }
    }
}
