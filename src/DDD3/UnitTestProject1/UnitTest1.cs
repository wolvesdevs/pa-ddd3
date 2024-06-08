using DDD3.UI.Services;
using DDD3.UI.ViewModels;
using Moq;
using Prism.Services.Dialogs;
using System.Windows;
using System.Windows.Controls;

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

    [Fact]
    public void ViewAのボタン2のテスト()
    {
        var dialogService = new Mock<IDialogService>();
        var messageService = new Mock<IMessageService>();

        messageService.Setup(x=>x.Question("Saveしますか？")).Returns(MessageBoxResult.OK);
        var vm = new ViewAViewModel(dialogService.Object, messageService.Object);

        messageService.Setup(x => x.ShowDialog(
            It.IsAny<string>()
            )).Callback<string>
                (message =>
                {
                    Assert.Equal("Saveしました", message);
                });

        vm.OKButton2.Execute();
        messageService.VerifyAll();
    }
}
