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
        public void シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1)).Returns(() =>
            {
                return new WeatherEntity(1, Convert.ToDateTime("2018/01/01 12:34:56"), 2, 12.3f);
            });

            var areasMock = new Mock<IAreasRepository>();

            var areas = new List<AreaEntity>
            {
                new AreaEntity(1, "東京"),
                new AreaEntity(2, "神戸"),
                new AreaEntity(3, "沖縄")
            };

            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModel = new WeatherLatestViewModel(weatherMock.Object, areasMock.Object);

            // 起動時は空文字を初期値とする
            viewModel.SelectedAreaId.Is(1);
            viewModel.DataDateText.Is("");
            viewModel.ConditionText.Is("");
            viewModel.TemperatureText.Is("");
            viewModel.Areas.Count.Is(3);
            viewModel.Areas[0].AreaId.Is(1);
            viewModel.Areas[0].AreaName.Is("東京");
            viewModel.Areas[1].AreaId.Is(2);
            viewModel.Areas[1].AreaName.Is("神戸");

            // 「直近値」ボタンテスト
            viewModel.SelectedAreaId = 1;
            viewModel.Search();
            viewModel.SelectedAreaId.Is(1);
            viewModel.DataDateText.Is("2018/01/01 12:34:56");
            viewModel.ConditionText.Is("曇り");
            viewModel.TemperatureText.Is("12.30 ℃");

            viewModel.SelectedAreaId = 3;
            viewModel.Search();
            viewModel.SelectedAreaId.Is(3);
            viewModel.DataDateText.Is("--");
            viewModel.ConditionText.Is("--");
            viewModel.TemperatureText.Is("--");
        }

    }
}