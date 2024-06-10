using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Repositories;
using DDDNET8.Infrastructure.SqlServer;
using System.ComponentModel;

namespace DDDNET8.UI.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;

        public WeatherListViewModel() : this(new WeatherSqlServer())
        {
        }

        public WeatherListViewModel(IWeatherRepository weather)
        {
            _weather = weather;
            Weathers = new(_weather.GetData().Select(entity => new WeatherListViewModelWeather(entity)).ToList());
        }

        public BindingList<WeatherListViewModelWeather> Weathers { get; set; } = new();
    }

    //public class WeatherListViewModel(IWeatherRepository weather) : ViewModelBase
    //{
    //    public WeatherListViewModel() : this(new WeatherSqlServer())
    //    {
    //    }

    //    public BindingList<WeatherListViewModelWeather> Weathers { get; set; }
    //    = new(weather.GetData().Select(entity => new WeatherListViewModelWeather(entity)).ToList());
    //}
}
