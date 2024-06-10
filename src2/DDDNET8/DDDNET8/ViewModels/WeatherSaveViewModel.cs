using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Exceptions;
using DDDNET8.Domain.Helpers;
using DDDNET8.Domain.Repositories;
using DDDNET8.Domain.ValueObjects;
using DDDNET8.Infrastructure.SqlServer;
using System.ComponentModel;

namespace DDDNET8.UI.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areas;

        public WeatherSaveViewModel() : this(new WeatherSqlServer(), new AreasSqlServer())
        {
        }

        public WeatherSaveViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            DataDateValue = GetDateTime();

            foreach (var area in _areas.GetData())
            {
                Areas.Add(area);
            }
        }

        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; } = Condition.Sunny.Value;
        public string TemperatureText { get; set; } = string.Empty;
        public BindingList<AreaEntity> Areas { get; set; } = new();
        public BindingList<Condition> Conditions { get; set; } = new(Condition.ToList());
        public string TemperatureUnitName { get; set; } = Temperature.UnitName;

        public void Save()
        {
            Guard.IsNull(SelectedAreaId, "エリアを選択してください");
            var temperature = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            var entity = new WeatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DataDateValue,
                Convert.ToInt32(SelectedCondition),
                temperature
                );

            _weather.Save(entity);
        }
    }
}
