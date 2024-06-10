using DDDNET8.Domain.Entities;
using DDDNET8.Domain.ValueObjects;

namespace DDDNET8.UI.ViewModels
{
    public sealed class WeatherListViewModelWeather(WeatherEntity entity)
    {
        private WeatherEntity _entity = entity;

        public string AreaId => _entity.AreaId.DisplayValue;
        public string AreaName => _entity.AreaName;
        public string DateData => _entity.DataDate.ToString();
        public string Condition => _entity.Condition.DisplayValue;
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }
}
