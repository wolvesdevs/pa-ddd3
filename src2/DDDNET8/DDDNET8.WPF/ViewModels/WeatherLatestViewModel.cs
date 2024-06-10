using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Repositories;
using DDDNET8.Infrastructure.SqlServer;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DDDNET8.WPF.ViewModels
{
    public class WeatherLatestViewModel : BindableBase
    {
        private IWeatherRepository _weatherRepository;
        private IAreasRepository _areasRepositoty;

        public WeatherLatestViewModel() : this(new WeatherSqlServer(), new AreasSqlServer())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weatherRepository = weather;
            _areasRepositoty = areas;

            foreach (var area in _areasRepositoty.GetData())
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

        private ObservableCollection<AreaEntity> _areas = new();
        public ObservableCollection<AreaEntity> Areas
        {
            get => _areas;
            set => SetProperty(ref _areas, value);
        }

        public void Search()
        {
            var entity = _weatherRepository.GetLatest(Convert.ToInt32(_selectedAreaId));

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
