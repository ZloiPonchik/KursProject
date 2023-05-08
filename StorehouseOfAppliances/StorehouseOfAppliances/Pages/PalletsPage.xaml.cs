using StorehouseOfAppliances.Models.AdditionalEntities;
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
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.ObjectModel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Win32;
using System.IO;

namespace StorehouseOfAppliances.Pages
{
    /// <summary>
    /// Логика взаимодействия для Pallets.xaml
    /// </summary>
    public partial class PalletsPage : Page
    {
        private ObservableCollection<PalletData> _pallets;

        public ObservableCollection<PalletData> Pallets1
        {
            get { return _pallets; }
            set
            {
                _pallets = value;
            }
        }
        public PalletsPage()
        {
            InitializeComponent();
            _pallets = new ObservableCollection<PalletData>(GetData());
            DataContext = this;

        }

        private void ButtonGoBackMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void ButtonAddPallet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPalletPage(null));
        }
        private List<PalletData> GetData()
        {
            using (var context = new StorehouseOfAppliancesContext())
            {
                var palletData = from pallet in context.Pallets

                            select new PalletData
                            {
                                Id = pallet.Id,
                                Length = pallet.Length,
                                Width = pallet.Width,
                                Height = pallet.Height,
                                Volume = Math.Round(pallet.Volume ?? 0, 3, MidpointRounding.AwayFromZero),
                                Weigth = pallet.Weight
                            };

                return palletData.ToList();
            }
        }

        private void ButtonDeleteDataTable_Click(object sender, RoutedEventArgs e)
        {
            if (PalletGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите паллет для удаления.");
                return;
            }

            var pallet = (PalletData)PalletGrid.SelectedItem;

            MessageBoxResult messageBoxResult = MessageBox.Show($"Вы действительно хотите удалить паллет {pallet.Id}?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using (var context = new StorehouseOfAppliancesContext())
                {
                    var palletToDelete = context.Pallets.FirstOrDefault(u => u.Id == pallet.Id);
                    if (palletToDelete != null)
                    {
                        context.Pallets.Remove(palletToDelete);
                        context.SaveChanges();
                        _pallets.Remove(pallet);
                        MessageBox.Show($"Паллет {pallet.Id} удален.");
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
                List<PalletData> data = new List<PalletData>();
                foreach (var item in PalletGrid.Items)
                {
                    PalletData? product = item as PalletData;
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
                float[] columnWidths = new float[] { 1f, 2f, 2f, 2f, 2f, 2f };
                table.SetWidths(columnWidths);

                // Добавляем заголовки таблицы
                table.AddCell(new PdfPCell(new Phrase("№", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Ширина (M)", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Длинна (M)", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Высота (M)", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Объем (М³)", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Вес (Кг)", headerFont)));

                // Добавляем данные из DataGrid в PDF-документ
                foreach (var item in data)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.Id.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Width.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Length.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Height.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Volume.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(item.Weigth.ToString(), font)));
                }

                document.Add(table);
                document.Close();
            }
        }
    }
}
