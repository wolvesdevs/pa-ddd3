using DDD3.UI.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace DDD3.UI.ViewModels;
public class MainWindowViewModel : BindableBase
{
    private IRegionManager _regionManager;
    private IDialogService _dialogService;

    private string _title = "PSamples";
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private bool _buttonEnabled = false;
    public bool ButtonEnabled
    {
        get => _buttonEnabled;
        set => SetProperty(ref _buttonEnabled, value);
    }

    private string _systemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    public string SystemDateLabel
    {
        get => _systemDateLabel;
        set => SetProperty(ref _systemDateLabel, value);
    }

    public DelegateCommand SystemDateUpdateButton { get; }
    public DelegateCommand ShowViewAButton { get; }
    public DelegateCommand ShowViewPButton { get; }
    public DelegateCommand ShowViewBButton { get; }
    public DelegateCommand ShowViewCButton { get; }

    public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
    {
        _regionManager = regionManager;
        _dialogService = dialogService;
        SystemDateUpdateButton = new DelegateCommand(SystemDateUpdateButtonExecute);
        ShowViewAButton = new DelegateCommand(ShowViewAButtonExecute).ObservesCanExecute(() => ButtonEnabled);
        ShowViewPButton = new DelegateCommand(ShowViewPButtonExecute);
        ShowViewBButton = new DelegateCommand(ShowViewBButtonExecute);
        ShowViewCButton = new DelegateCommand(ShowViewCButtonExecute);
    }

    private void SystemDateUpdateButtonExecute()
    {
        ButtonEnabled = true;
        SystemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }

    private void ShowViewAButtonExecute()
    {
        _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
    }

    private void ShowViewPButtonExecute()
    {
        NavigationParameters p = new();
        p.Add(nameof(ViewAViewModel.MyLabel), SystemDateLabel);
        _regionManager.RequestNavigate("ContentRegion", nameof(ViewA), p);
    }

    private void ShowViewBButtonExecute()
    {
        DialogParameters p = new();
        p.Add(nameof(ViewBViewModel.ViewBTextBox), SystemDateLabel);
        _dialogService.ShowDialog(nameof(ViewB), p, ViewBClose);
    }

    private void ViewBClose(IDialogResult dialogResult)
    {
        if (dialogResult.Result == ButtonResult.OK)
        {
            SystemDateLabel = dialogResult.Parameters.GetValue<string>(nameof(ViewBViewModel.ViewBTextBox));
        }
    }

    private void ShowViewCButtonExecute()
    {
        _regionManager.RequestNavigate("ContentRegion", nameof(ViewC));
    }

}
