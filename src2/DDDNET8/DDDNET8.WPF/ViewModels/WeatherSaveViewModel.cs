using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Helpers;
using DDDNET8.Domain.Repositories;
using DDDNET8.Domain.ValueObjects;
using DDDNET8.Infrastructure.SqlServer;
using DDDNET8.WPF.Services;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace DDDNET8.WPF.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase, IDialogAware
    {
        private IWeatherRepository _weatherRepository;
        private IAreasRepository _areasRespository;
        private IMessageService _messageService;

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand SaveButton { get; }

        public string Title => "登録画面";

        private AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get => _selectedArea;
            set => SetProperty(ref _selectedArea, value);
        }

        public DateTime? DataDateValue { get; set; }

        private Condition _selectedCondition;
        public Condition SelectedCondition
        {
            get => _selectedCondition;
            set => SetProperty(ref _selectedCondition, value);
        }

        private string _temperatureText;
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

        private ObservableCollection<Condition> _conditions = new(Condition.ToList());
        public ObservableCollection<Condition> Conditions
        {
            get => _conditions;
            set => SetProperty(ref _conditions, value);
        }

        public string TemperatureUnitName => Temperature.UnitName;

        #region コンストラクタ

        public WeatherSaveViewModel() : this(new WeatherSqlServer(), new AreasSqlServer(), new MessageService()) { }

        public WeatherSaveViewModel(IWeatherRepository weather, IAreasRepository areas, IMessageService messageService)
        {
            _weatherRepository = weather;
            _areasRespository = areas;
            _messageService = messageService;

            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny;
            TemperatureText = string.Empty;

            foreach (var area in _areasRespository.GetData())
            {
                Areas.Add(area);
            }

            SaveButton = new DelegateCommand(SaveExecute);
        }

        #endregion

        private void SaveExecute()
        {
            Guard.IsNull(SelectedArea, "エリアを選択してください");
            Guard.IsNull(DataDateValue, "日時を入力してください");
            var temperature = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            if(_messageService.Question("登録しますか？") != System.Windows.MessageBoxResult.OK)
            {
                return;
            }

            var entity = new WeatherEntity(
                SelectedArea.AreaId,
                DataDateValue.Value,
                SelectedCondition.Value,
                temperature
                );

            _weatherRepository.Save(entity);

            _messageService.ShowDialog("登録しました。");
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
