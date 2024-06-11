using DDDNET8.Domain.Exceptions;
using DDDNET8.WPF.Views;
using Prism.Ioc;
using System.Windows;
using System.Windows.Threading;

namespace DDDNET8.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //_logger.Error(ex.Message, ex);

            MessageBoxImage icon = MessageBoxImage.Error;
            string caption = "エラー";

            if (e.Exception is ExceptionBase exceptionBase)
            {
                switch (exceptionBase.Kind)
                {
                    case ExceptionBase.ExceptionKind.Information:
                        icon = MessageBoxImage.Information; 
                        caption = "情報";
                        break;
                    case ExceptionBase.ExceptionKind.Warning:
                        icon = MessageBoxImage.Warning;
                        caption = "警告";
                        break;
                }
            }

            MessageBox.Show(e.Exception.Message, caption, MessageBoxButton.OK, icon);

            e.Handled = true;
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WeatherLatestView>();
            containerRegistry.RegisterForNavigation<WeatherListView>();
        }
    }
}
