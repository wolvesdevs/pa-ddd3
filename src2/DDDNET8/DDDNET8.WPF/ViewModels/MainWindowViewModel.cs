using DDDNET8.WPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace DDDNET8.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRegionManager _regionManager;
        private IDialogService _dialogService;

        public DelegateCommand WeatherLatestButton { get; }
        public DelegateCommand WeatherListButton { get; }
        public DelegateCommand WeatherSaveButton { get; }

        private string _title = "DDD";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _statusLabel = "--";
        public string StatusLabel
        {
            get => _statusLabel;
            set => SetProperty(ref _statusLabel, value);
        }

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            WeatherLatestButton = new DelegateCommand(WeatherLatestButtonExecute);
            WeatherListButton = new DelegateCommand(WeatherListButtonExecute);
            WeatherSaveButton = new DelegateCommand(WeatherSaveButtonExecute);
        }

        private void WeatherLatestButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(WeatherLatestView));
        }

        private void WeatherListButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(WeatherListView));
        }

        private void WeatherSaveButtonExecute()
        {
            _dialogService.ShowDialog(nameof(WeatherSaveView), null, null);
        }
    }
}
