using DDD3.UI.ViewModels;
using Moq;
using Prism.Services.Dialogs;

namespace UnitTestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var mock = new Mock<IDialogService>();
        var vm = new ViewAViewModel(mock.Object);

        mock.Setup(x => x.ShowDialog(
            It.IsAny<string>(),
            It.IsAny<IDialogParameters>(),
            It.IsAny<Action<IDialogResult>>()
            )).Callback<
                string, 
                IDialogParameters, 
                Action<IDialogResult>>
                ((viewName, p, result) =>
                {
                    Assert.Equal("ViewB", viewName);
                });

        vm.OKButton.Execute();
    }
}
