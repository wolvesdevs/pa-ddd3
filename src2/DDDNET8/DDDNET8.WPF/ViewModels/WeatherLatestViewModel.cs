using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Exceptions;
using DDDNET8.Domain.Repositories;
using DDDNET8.Infrastructure.SqlServer;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace DDDNET8.WPF.ViewModels
{
    public class WeatherLatestViewModel : BindableBase
    {
        private IWeatherRepository _weatherRepository;
        private IAreasRepository _areasRepositoty;

        public DelegateCommand LatestButton { get; }

        private ObservableCollection<AreaEntity> _areas = new();
        public ObservableCollection<AreaEntity> Areas
        {
            get => _areas;
            set => SetProperty(ref _areas, value);
        }

        private AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get => _selectedArea;
            set => SetProperty(ref _selectedArea, value);
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

        #region コンストラクタ

        public WeatherLatestViewModel() : this(new WeatherSqlServer(), new AreasSqlServer()) { }

        public WeatherLatestViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weatherRepository = weather;
            _areasRepositoty = areas;

            foreach (var area in _areasRepositoty.GetData())
            {
                Areas.Add(area);
            }

            LatestButton = new DelegateCommand(LatestButtonExecute);
        }

        #endregion

        private void LatestButtonExecute()
        {
            if (SelectedArea == null)
            {
                throw new InputException("地域を選択してください。");
            }

            var entity = _weatherRepository.GetLatest(SelectedArea.AreaId);

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
