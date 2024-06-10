using ChainingAssertion;
using DDDNET8.Domain.ValueObjects;

namespace DDDNET8Test.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点以下2桁でまるめて表示できる()
        {
            var t = new Temperature(12.3f);

            t.Value.Is(12.3f);
            t.DisplayValue.Is("12.30");
            t.DisplayValueWithUnit.Is("12.30℃");
            t.DisplayValueWithUnitSpace.Is("12.30 ℃");
        }

        [TestMethod]
        public void ValueObjectインスタンスEquals()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            t1.Equals(t2).IsTrue();
        }

        [TestMethod]
        public void ValueObjectインスタンス等価演算子()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            (t1 == t2).IsTrue();
        }
    }
}