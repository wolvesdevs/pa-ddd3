using Prism.Mvvm;

namespace DDDNET8.WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "DDD";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel()
        {

        }
    }
}
