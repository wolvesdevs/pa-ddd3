using DDDNET8.UI.ViewModels;

namespace DDDNET8.UI.Views
{
    public partial class WeatherListView : Form
    {
        private WeatherListViewModel _viewModel = new WeatherListViewModel();

        public WeatherListView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            WeathersDataGrid.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Weathers));
        }
    }
}
