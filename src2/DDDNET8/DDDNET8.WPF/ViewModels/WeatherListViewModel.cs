using DDDNET8.Domain.Repositories;
using DDDNET8.Infrastructure.SqlServer;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DDDNET8.WPF.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private MainWindowViewModel _mainWindowViewModel;

        public DelegateCommand UpdateButton { get; }
        public DelegateCommand DataGridSelectionChanged { get; }
        public DelegateCommand DataGridMouseDoubleClick { get; }

        private ObservableCollection<WeatherListViewModelWeather> _weathers = new();
        public ObservableCollection<WeatherListViewModelWeather> Weathers
        {
            get => _weathers;
            set => SetProperty(ref _weathers, value);
        }

        private WeatherListViewModelWeather _selectedWeather;
        public WeatherListViewModelWeather SelectedWeather
        {
            get => _selectedWeather;
            set => SetProperty(ref _selectedWeather, value);
        }

        #region コンストラクタ

        public WeatherListViewModel(MainWindowViewModel mainWindowViewModel) : this(new WeatherSqlServer(), mainWindowViewModel) { }

        public WeatherListViewModel(IWeatherRepository weather, MainWindowViewModel mainWindowViewModel)
        {
            _weather = weather;
            _mainWindowViewModel = mainWindowViewModel;

            Weathers = new(_weather.GetData().Select(entity => new WeatherListViewModelWeather(entity)).ToList());

            UpdateButton = new DelegateCommand(UpdateButtonExecute);
            DataGridSelectionChanged = new DelegateCommand(DataGridSelectionChangedExecute);
            DataGridMouseDoubleClick = new DelegateCommand(DataGridMouseDoubleClickExecute);
        }

        #endregion

        #region メソッド

        private void UpdateButtonExecute()
        {
            _mainWindowViewModel.StatusLabel = "更新しました。";
        }

        private void DataGridSelectionChangedExecute()
        {

        }

        private void DataGridMouseDoubleClickExecute()
        {

        }

        #endregion
    }
}
