using DDDNET8.Domain.Entities;
using DDDNET8.Domain.ValueObjects;
using DDDNET8.UI.ViewModels;

namespace DDDNET8.UI.Views
{
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel _viewModel = new();

        public WeatherSaveView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AreaIdComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            AreaIdComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Areas));
            AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);
            AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);
            DateTimeTextBox.DataBindings.Add("Value", _viewModel, nameof(_viewModel.DataDateValue));
            ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ConditionComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedCondition));
            ConditionComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Conditions));
            ConditionComboBox.ValueMember = nameof(Condition.Value);
            ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);
            TemperatureTextBox.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureText));
            UnitLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureUnitName));

            SaveButton.Click += (_, __) =>
            {
                try
                {
                    _viewModel.Save();
                    MessageBox.Show("登録しました。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }
    }
}
