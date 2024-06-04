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

    public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
    {
        _regionManager = regionManager;
        _dialogService = dialogService;
        SystemDateUpdateButton = new DelegateCommand(SystemDateUpdateButtonExecute);
        ShowViewAButton = new DelegateCommand(ShowViewAButtonExecute);
        ShowViewBButton = new DelegateCommand(ShowViewBButtonExecute);
    }

    private void SystemDateUpdateButtonExecute()
    {
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
        _dialogService.ShowDialog(nameof(ViewB), null, null);
    }
}
