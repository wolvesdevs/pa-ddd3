using ChainingAssertion;
using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Repositories;
using DDDNET8.UI.ViewModels;
using Moq;

namespace DDDNET8Test.Tests
{
    [TestClass]
    public class WeatherListViewModelTest
    {
        [TestMethod]
        public void �V�C�ꗗ��ʃV�i���I()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            var entities = new List<WeatherEntity>
            {
                new(1, "����", Convert.ToDateTime("2018/01/01 12:34:56"), 2, 12.3f),
                new(2, "�_��", Convert.ToDateTime("2018/01/02 12:34:56"), 1, 22.1234f)
            };

            weatherMock.Setup(x => x.GetData()).Returns(entities);

            var viewModel = new WeatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);

            viewModel.Weathers[0].AreaId.Is("0001");
            viewModel.Weathers[0].AreaName.Is("����");
            viewModel.Weathers[0].DateData.Is("2018/01/01 12:34:56");
            viewModel.Weathers[0].Condition.Is("�܂�");
            viewModel.Weathers[0].Temperature.Is("12.30 ��");
        }
    }
}