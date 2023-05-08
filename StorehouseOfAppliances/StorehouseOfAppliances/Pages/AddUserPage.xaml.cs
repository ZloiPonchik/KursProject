using StorehouseOfAppliances.Models;
using StorehouseOfAppliancesPasswordCheckerPasswordChecker;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Security.Cryptography;
using MessageBox = System.Windows.MessageBox;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Text.RegularExpressions;

namespace StorehouseOfAppliances.Pages
{
    // Класс AddUserPage представляет страницу для добавления новых пользователей в базу данных.
    public partial class AddUserPage : Page
    {
        //Объявление переменной _user, которая хранит информацию о пользователе.
        //Переменная может принимать значение null.
        private User? _user = new User();

        //Объявление события PropertyChanged, которое возникает при изменении свойств объекта.
        public event PropertyChangedEventHandler? PropertyChanged;

        //Свойство User, которое возвращает объект _user и устанавливает его новое значение при изменении.
        public User? User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        //Свойство Roles, которое представляет коллекцию ролей, инициализируемую при создании объекта AddUserPage.
        public ObservableCollection<Role> Roles { get; set; }

        //Конструктор класса AddUserPage, который принимает тип доступа и объект пользователя.
        //В конструкторе происходит инициализация объекта PasswordChecker, определение типа доступа к странице,
        //инициализация коллекции ролей, а также установка свойства DataContext равным текущему объекту AddUserPage.
        public AddUserPage(User? user = null)
        {
            InitializeComponent();
            _passwordChecker = new PasswordChecker();
           
            Roles = new ObservableCollection<Role>(App.Context.Roles.ToList());


            GridMain.DataContext = this;
        }

        //Объявление переменной idRole, которая будет хранить идентификатор выбранной роли.
        int idRole = 0;

        //Обработчик нажатия на кнопку сохранения данных.
        //При нажатии происходит проверка наличия изображения пользователя и загрузка базового изображения, если его нет.
        //Далее выбирается идентификатор роли в зависимости от выбранного элемента в ComboBoxRoles.
        //После этого происходит проверка на наличие ошибок в заполнении данных о пользователе.
        //Если ошибок нет, то создается новый объект User, добавляется в базу данных и происходит переход на страницу с пользователями.
        //Если возникла ошибка, то выводится сообщение об ошибке.
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {   
            if (User.Image == null)
            {
                var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Avatar", "BaseAvatar.png");

                if (File.Exists(imagePath))
                {
                    using (var imageStream = new MemoryStream(File.ReadAllBytes(imagePath)))
                    {
                        var encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(imageStream));

                        using (var output = new MemoryStream())
                        {
                            encoder.Save(output);

                            User.Image = output.ToArray();
                        }
                    }
                }
            }
            switch (ComboBoxRoles.Text)
            {
                case "Admin":
                    idRole = 1;
                    break;
                case "Storekeeper":
                    idRole = 2;
                    break;
            }

            string message = CheckErrors();

            if (string.IsNullOrEmpty(message))
            {
                try
                    {
                    User user = new User()
                    {
                        Login = User.Login,
                        Password = Decode(password.Password),
                        LastName = User.LastName,
                        FirstName = User.FirstName,
                        Patronymic = User.Patronymic,
                        TelephoneNumber = User.TelephoneNumber,
                        RoleId = idRole,
                        Image = User.Image
                    };

                    App.Context.Users.Add(user);
                    App.Context.SaveChanges();
                    MessageBox.Show("Пользователь создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new UsersPage());

                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!","Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                ShowErrorMessage(message);
            }
        }

        // Метод ShowErrorMessage используется для отображения сообщения об ошибке в диалоговом окне.
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void OnPropertyChanged([CallerMemberName] string? property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        private void ComboBoxRoles_SelectionChanged(object sender, RoutedEventArgs e)
        {
            User.Role = ComboBoxRoles.SelectedItem as Role;
        }

        private readonly PasswordChecker _passwordChecker;

        //Кнопка перехода на страницу пользователей
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }
        //Кнопка возвращение в меню
        private void ButtonGoBackMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        // Метод CheckErrors используется для проверки полей на форме на наличие ошибок.
        private string CheckErrors()
        {        
            // Он возвращает строку с описанием ошибок (если они есть).
            string errorMessage = "";
           
            // Проверяем, есть ли в базе данных пользователь с таким же логином, как у текущего пользователя
            User? user = App.Context.Users
                .Where(item => item.Login.ToLower() == (login.Text.ToLower()))
                .FirstOrDefault();

            // Проверяем, что Логин не пустой и состоит только из английских букв и цифр
            if (string.IsNullOrEmpty(User.Login))
            {
                errorMessage += "Введите Логин!\n";
            }
            else if (!Regex.IsMatch(User.Login, "^[a-zA-Z0-9]+$"))
            {
                errorMessage += "Логин может содержать только английские буквы и цифры!\n";
            }
            // Проверяем, что пользователь с таким логином не существует в базе данных
            else if (user != null)
            {
                errorMessage += "Пользователь с таким логином уже существует в системе!\n";
            }
            // Проверяем, что Логин не превышает максимальное количество символов
            else if (User.Login.Length > 15)
            {
                errorMessage += "Превышено максимальное количество символов в логине (Не более 15 символов)!\n";
            }

            // Проверяем, что пароль не пустой и соответствует условиям сложности
            if (string.IsNullOrEmpty(password.Password) 
                || password.Password.Length < 8
                || !password.Password.Any(char.IsUpper)
                || !password.Password.Any(char.IsLower)
                || !password.Password.Any(char.IsDigit)
                || !password.Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errorMessage += "Пароль должен содержать не менее 8 символов, включая заглавную букву, строчную букву, цифру и символ!\n";
            }

            // Проверяем, что Фамилия не пустая, состоит только из русских букв и начинается с заглавной буквы
            if (string.IsNullOrEmpty(User.LastName))
            {
                errorMessage += "Введите Фамилию!\n";
            }
            else if (!Regex.IsMatch(User.LastName, "^[А-ЯЁ][а-яё]*$"))
            {
                errorMessage += "Фамилия может содержать только русские буквы и должна начинаться с заглавной буквы!\n";
            }
            // Проверяем, что Фамилия не превышает максимальное количество символов
            else if (User.LastName.Length > 15)
            {
                errorMessage += "Превышено максимальное количество символов в Фамилии (Не более 15 символов)!\n";
            }

            // Проверяем, что Имя не пустое, состоит только из русских букв и начинается с заглавной буквы
            if (string.IsNullOrEmpty(User.FirstName))
            {
                errorMessage += "Введите Имя!\n";
            }
            else if (!Regex.IsMatch(User.FirstName, "^[А-ЯЁ][а-яё]*$"))
            {
                errorMessage += "Имя может содержать только русские буквы и должно начинаться с заглавной буквы!\n";
            }
            // Проверяем, что Имя не превышает максимальное количество символов
            else if (User.FirstName.Length > 15)
            {
                errorMessage += "Превышено максимальное количество символов в Имени (Не более 15 символов)!\n";
            }

            // Проверяем, что Отчество состоит только из русских букв и начинается с заглавной буквы
            if (!string.IsNullOrEmpty(User.Patronymic) && !Regex.IsMatch(User.Patronymic, @"^[А-ЯЁ][а-яё]*$"))
            {
                errorMessage += "Отчество должно начинаться с большой буквы и содержать только русские буквы!\n";
            }
            // Проверяем, что Отчество не превышает максимальное количество символов
            else if (!string.IsNullOrEmpty(User.Patronymic) && User.Patronymic.Length > 20)
            {
                errorMessage += "Превышено максимальное количество символов в Отчестве (Не более 20 символов)!\n";
            }

            // Проверяем, что Телефон не пустой, и начинается с цифры 8, а также имеет 11 цифр
            if (string.IsNullOrEmpty(User.TelephoneNumber))
            {
                errorMessage += "Введите номер телефона!\n";
            }
            else if (!Regex.IsMatch(User.TelephoneNumber, @"^8\d{10}$"))
            {
                errorMessage += "Номер телефона должен начинаться с цифры 8 и содержать 11 цифр!\n";
            }

            // Проверяем, что Роль выбрана
            if (User.Role == null)
            {
                errorMessage += "Выберете роль!\n";
            }
            return errorMessage;
        }

        //Метод Decode использует алгоритм SHA256 для вычисления хэша заданного password,
        //а затем возвращает результат в виде строки, закодированной в системной кодировке по умолчанию.
        private string Decode(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        //Обработчик события для нажатия кнопки, который открывает диалоговое окно файла,
        //позволяющее пользователю выбрать файл изображения. Если пользователь выбирает файл и нажимает «ОК»,
        //код считывает содержимое файла в массив байтов и передает этот массив методу ChangeImageUser.
        private void ButtonAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = "*.png",
                Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ChangeImageUser(File.ReadAllBytes(openFileDialog.FileName));
            }
        }

        //Метод ChangeImageUser берет массив байтов и присваивает его свойству Image объекта User.
        private void ChangeImageUser(byte[] imageDate)
        {
            User.Image = imageDate;
            OnPropertyChanged("User");
        }

        //Обработчик события, который запускается, когда пользователь вводит новый символ в поле пароля.
        //Код проверяет, пусто ли поле пароля, и если да, то скрывает индикатор уровня сложности пароля.
        //Если поле пароля не пусто, код показывает индикатор уровня сложности пароля и использует перечисление PasswordComplexityLevel
        //для проверки надежности пароля.
        //Метод Checkобъекта _passwordCheckerвозвращает надежность пароля в виде PasswordComplexityLevel
        //значения перечисления, которое затем используется для обновления значения, цвета и текста индикатора выполнения,
        //указывающего надежность пароля.
        private void password_PasswordChange(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(password.Password))
            {
                passwordComplexityLevel.Visibility = Visibility.Collapsed;
            }
            else
            {
                passwordComplexityLevel.Visibility = Visibility.Visible;
                PasswordComplexityLevel level = _passwordChecker.Check(password.Password);
                passwordComplexityLevelProgressBar.Value = (int)level;
                passwordComplexityLevelProgressBar.Foreground = (SolidColorBrush?)(new BrushConverter().ConvertFrom(level.ToHex()));
                passwordComplexityLevelText.Text = level.ToName();
            }
        }
    }
}

