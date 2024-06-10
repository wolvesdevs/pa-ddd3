using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Repositories;
using DDDNET8.Infrastructure.SqlServer;
using System.ComponentModel;

namespace DDDNET8.UI.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areas;

        public WeatherLatestViewModel() : this(new WeatherSqlServer(), new AreasSqlServer())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(area);
            }
        }

        private object _selectedAreaId = 1;
        public object SelectedAreaId
        {
            get => _selectedAreaId;
            set => SetProperty(ref _selectedAreaId, value);
        }

        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get => _dataDateText;
            set => SetProperty(ref _dataDateText, value);
        }

        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get => _conditionText;
            set => SetProperty(ref _conditionText, value);
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get => _temperatureText;
            set => SetProperty(ref _temperatureText, value);
        }

        public BindingList<AreaEntity> Areas { get; set; } = new();

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(_selectedAreaId));

            if (entity == null)
            {
                DataDateText = "--";
                ConditionText = "--";
                TemperatureText = "--";
            }
            else
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}
