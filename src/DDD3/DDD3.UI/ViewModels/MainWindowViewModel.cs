using Prism.Commands;
using Prism.Mvvm;
using System;

namespace DDD3.UI.ViewModels;
public class MainWindowViewModel : BindableBase
{
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

    public MainWindowViewModel()
    {
        SystemDateUpdateButton = new DelegateCommand(SystemDateUpdateButtonExecute);
    }

    private void SystemDateUpdateButtonExecute()
    {
        SystemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }
}
