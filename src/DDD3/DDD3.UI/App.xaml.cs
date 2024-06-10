using DDD3.UI.ViewModels;
using DDD3.UI.Views;
using Prism.Ioc;
using System.Windows;

namespace DDD3.UI;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA>();
        containerRegistry.RegisterForNavigation<ViewC>();
        containerRegistry.RegisterDialog<ViewB, ViewBViewModel>();

        containerRegistry.RegisterSingleton<MainWindowViewModel>();
    }
}
