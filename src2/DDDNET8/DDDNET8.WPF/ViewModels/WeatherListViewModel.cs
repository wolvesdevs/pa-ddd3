using DDDNET8.Domain.Repositories;
using DDDNET8.Infrastructure.SqlServer;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace DDDNET8.WPF.ViewModels
{
    public class WeatherListViewModel : BindableBase
    {
        private IWeatherRepository _weather;

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

        public WeatherListViewModel() : this(new WeatherSqlServer()) { }

        public WeatherListViewModel(IWeatherRepository weather)
        {
            _weather = weather;
            Weathers = new(_weather.GetData().Select(entity => new WeatherListViewModelWeather(entity)).ToList());
        }

        #endregion
    }
}
