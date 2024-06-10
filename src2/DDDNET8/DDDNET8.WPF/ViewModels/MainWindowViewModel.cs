using DDDNET8.WPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace DDDNET8.WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;

        private DelegateCommand WeatherLatestButton { get; }

        private string _title = "DDD";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            WeatherLatestButton = new DelegateCommand(WeatherLatestButtonExecute);
        }

        private void WeatherLatestButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(WeatherLatestView));
        }
    }
}
