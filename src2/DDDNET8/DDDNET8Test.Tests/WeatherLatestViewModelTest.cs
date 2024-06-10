using ChainingAssertion;
using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Repositories;
using DDDNET8.UI.ViewModels;
using Moq;

namespace DDDNET8Test.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void �V�i���I()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1)).Returns(() =>
            {
                return new WeatherEntity(1, Convert.ToDateTime("2018/01/01 12:34:56"), 2, 12.3f);
            });

            var areasMock = new Mock<IAreasRepository>();

            var areas = new List<AreaEntity>
            {
                new AreaEntity(1, "����"),
                new AreaEntity(2, "�_��"),
                new AreaEntity(3, "����")
            };

            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModel = new WeatherLatestViewModel(weatherMock.Object, areasMock.Object);

            // �N�����͋󕶎��������l�Ƃ���
            viewModel.SelectedAreaId.Is(1);
            viewModel.DataDateText.Is("");
            viewModel.ConditionText.Is("");
            viewModel.TemperatureText.Is("");
            viewModel.Areas.Count.Is(3);
            viewModel.Areas[0].AreaId.Is(1);
            viewModel.Areas[0].AreaName.Is("����");
            viewModel.Areas[1].AreaId.Is(2);
            viewModel.Areas[1].AreaName.Is("�_��");

            // �u���ߒl�v�{�^���e�X�g
            viewModel.SelectedAreaId = 1;
            viewModel.Search();
            viewModel.SelectedAreaId.Is(1);
            viewModel.DataDateText.Is("2018/01/01 12:34:56");
            viewModel.ConditionText.Is("�܂�");
            viewModel.TemperatureText.Is("12.30 ��");

            viewModel.SelectedAreaId = 3;
            viewModel.Search();
            viewModel.SelectedAreaId.Is(3);
            viewModel.DataDateText.Is("--");
            viewModel.ConditionText.Is("--");
            viewModel.TemperatureText.Is("--");
        }

    }
}