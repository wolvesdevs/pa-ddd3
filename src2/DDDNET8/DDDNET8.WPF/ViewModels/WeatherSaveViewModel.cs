using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Helpers;
using DDDNET8.Domain.Repositories;
using DDDNET8.Domain.ValueObjects;
using DDDNET8.Infrastructure.SqlServer;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace DDDNET8.WPF.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase, IDialogAware
    {
        private IWeatherRepository _weatherRepository;
        private IAreasRepository _areasRespository;

        public event Action<IDialogResult> RequestClose;

        private AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get => _selectedArea;
            set => SetProperty(ref _selectedArea, value);
        }

        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; } = Condition.Sunny.Value;
        public string TemperatureText { get; set; } = string.Empty;

        private ObservableCollection<AreaEntity> _areas = new();
        public ObservableCollection<AreaEntity> Areas
        {
            get => _areas;
            set => SetProperty(ref _areas, value);
        }

        private ObservableCollection<Condition> _conditions = new(Condition.ToList());
        public ObservableCollection<Condition> Conditions
        {
            get => _conditions;
            set => SetProperty(ref _conditions, value);
        }

        public string TemperatureUnitName { get; set; } = Temperature.UnitName;

        public string Title => "登録画面";

        #region コンストラクタ

        public WeatherSaveViewModel() : this(new WeatherSqlServer(), new AreasSqlServer()) { }

        public WeatherSaveViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weatherRepository = weather;
            _areasRespository = areas;

            DataDateValue = GetDateTime();

            foreach (var area in _areasRespository.GetData())
            {
                Areas.Add(area);
            }
        }

        #endregion

        public void Save()
        {
            Guard.IsNull(SelectedArea, "エリアを選択してください");
            var temperature = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            var entity = new WeatherEntity(
                SelectedArea.AreaId,
                DataDateValue,
                Convert.ToInt32(SelectedCondition),
                temperature
                );

            _weatherRepository.Save(entity);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
