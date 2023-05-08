using StorehouseOfAppliances.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace StorehouseOfAppliances
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly StorehouseOfAppliancesContext Context = new StorehouseOfAppliancesContext();
        public static User CurrentUser = null;

        /// <summary>
        /// Метод для настройки глобальных настроек приложения
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Настраиваем главное окно приложения
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        }

        /// <summary>
        /// Используется в качестве глобального обработчика событий
        /// </summary>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Не волнуйтесь! Произошла непредвиденная ошибка приложения: {((Exception)e.ExceptionObject).Message}. Обратитесь к администратору!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Используется в качестве глобального обработчика событий
        /// </summary>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show($"Не волнуйтесь! Произошла непредвиденная ошибка приложения: {e.Exception.Message}. Обратитесь к администратору!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Используется когда происходит ошибка в асинхронном коде
        /// </summary>
        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            MessageBox.Show($"Не волнуйтесь! Произошла непредвиденная ошибка приложения: {e.Exception.Message}. Обратитесь к администратору!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
