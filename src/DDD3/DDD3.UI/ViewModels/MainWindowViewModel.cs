using Prism.Mvvm;

namespace DDD3.UI.ViewModels;
public class MainWindowViewModel : BindableBase
{
    private string _title = "PSamples";
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public MainWindowViewModel()
    {

    }
}
