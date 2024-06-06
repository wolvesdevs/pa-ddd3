using DDD3.UI.ViewModels;

namespace UnitTestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var vm = new ViewAViewModel();
        vm.OKButton.Execute();
    }
}
