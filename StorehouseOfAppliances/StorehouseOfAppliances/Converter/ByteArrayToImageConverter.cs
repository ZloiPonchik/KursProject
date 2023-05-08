using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace StorehouseOfAppliances.Converter
{
    // Класс ByteArrayToImageConverter преобразует массив байтов в BitmapImage с помощью интерфейса IValueConverter.
    [ValueConversion(typeof(byte[]), typeof(BitmapImage))]
    public class ByteArrayToImageConverter : IValueConverter
    {
        // Метод Convert() получает массив байтов и проверяет, что его длина больше нуля.
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is byte[] byteArray && byteArray.Length > 0)
            {    
                // Затем метод создает новый объект BitmapImage и заполняет его данными из MemoryStream, созданного из массива байтов.
                BitmapImage image = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }
                return image;
            }
            return null;
        }

        // Метод ConvertBack() не реализован и выбрасывает исключение NotImplementedException().
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
