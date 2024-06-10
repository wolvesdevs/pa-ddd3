using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Helpers;
using DDDNET8.Infrastructure.SqlServer;
using DDDNET8.UI.ViewModels;
using DDDNET8.UI.Views;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DDDNET8.UI
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();

        public WeatherLatestView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AreasComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            AreasComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Areas));
            AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);
            DataDateLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DataDateText));
            ConditionLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ConditionText));
            TemperatureLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherListView())
            {
                f.ShowDialog();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherSaveView())
            {
                f.ShowDialog();
            }
        }
    }
}
