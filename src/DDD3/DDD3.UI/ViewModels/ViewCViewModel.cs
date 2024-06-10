using DDD3.UI.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace DDD3.UI.ViewModels;
public class ViewCViewModel : BindableBase, IConfirmNavigationRequest
{
    #region フィールド＆プロパティ

    private IMessageService _messageService;
    private MainWindowViewModel _mainWindowViewModel;

    public DelegateCommand<object[]> AreaSelectionChanged { get; }

    private ObservableCollection<string> _myListBox = new();
    public ObservableCollection<string> MyListBox
    {
        get => _myListBox;
        set => SetProperty(ref _myListBox, value);
    }

    private ObservableCollection<ComboBoxViewModel> _areas = new();
    public ObservableCollection<ComboBoxViewModel> Areas
    {
        get => _areas;
        set => SetProperty(ref _areas, value);
    }

    private ComboBoxViewModel _selectedArea;
    public ComboBoxViewModel SelectedArea
    {
        get => _selectedArea;
        set => SetProperty(ref _selectedArea, value);
    }

    private string _selectedAreaLabel;
    public string SelectedAreaLabel
    {
        get => _selectedAreaLabel;
        set => SetProperty(ref _selectedAreaLabel, value);
    }

    #endregion

    #region コンストラクタ

    public ViewCViewModel(MainWindowViewModel mainWindowViewModel) : this(new MessageService(), mainWindowViewModel) { }

    public ViewCViewModel(IMessageService messageService, MainWindowViewModel mainWindowViewModel)
    {
        _messageService = messageService;
        _mainWindowViewModel = mainWindowViewModel;

        MyListBox.Add("AAA");
        MyListBox.Add("BBB");
        MyListBox.Add("CCC");

        Areas.Add(new ComboBoxViewModel(1, "東京"));
        Areas.Add(new ComboBoxViewModel(2, "大阪"));
        Areas.Add(new ComboBoxViewModel(3, "名古屋"));

        SelectedArea = Areas[1];

        AreaSelectionChanged = new DelegateCommand<object[]>(AreaSelectionChangedExecute);
    }

    #endregion

    #region メソッド

    public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
        if (_messageService.Question("とじますか？") == MessageBoxResult.OK)
        {
            continuationCallback(true);
        }
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return false;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
    }


    private void AreaSelectionChangedExecute(object items)
    {
        SelectedAreaLabel = SelectedArea.Value + " : " + SelectedArea.DisplayValue;

        _mainWindowViewModel.Title = SelectedAreaLabel;
    }

    #endregion
}
