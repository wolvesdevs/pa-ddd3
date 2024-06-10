using ChainingAssertion;
using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Exceptions;
using DDDNET8.Domain.Repositories;
using DDDNET8.UI.ViewModels;
using Moq;

namespace DDDNET8Test.Tests
{
    [TestClass]
    public class WeatherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            var areasMock = new Mock<IAreasRepository>();

            var areas = new List<AreaEntity>
            {
                new(1, "東京"),
                new(2, "神戸"),
            };

            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModelMock = new Mock<WeatherSaveViewModel>(weatherMock.Object, areasMock.Object);
            viewModelMock.Setup(x => x.GetDateTime()).Returns(Convert.ToDateTime("2018/01/01 12:34:56"));

            var viewModel = viewModelMock.Object;
            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");
            viewModel.TemperatureUnitName.Is("℃");

            viewModel.Areas.Count.Is(2);
            viewModel.Conditions.Count.Is(4);

            var ex = ExceptionAssert.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("エリアを選択してください");

            viewModel.SelectedAreaId = 2;
            ex = ExceptionAssert.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("温度の入力に誤りがあります");

            viewModel.TemperatureText = "12.345";

            weatherMock.Setup(x => x.Save(It.IsAny<WeatherEntity>())).
                Callback<WeatherEntity>(saveValue =>
                {
                    saveValue.AreaId.Value.Is(2);
                    saveValue.DataDate.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
                    saveValue.Condition.Value.Is(1);
                    saveValue.Temperature.Value.Is(12.345f);
                });

            viewModel.Save();
            weatherMock.VerifyAll();
        }
    }
}