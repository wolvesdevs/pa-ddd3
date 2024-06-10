using ChainingAssertion;
using DDDNET8.Domain.ValueObjects;

namespace DDDNET8Test.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void �����_�ȉ�2���ł܂�߂ĕ\���ł���()
        {
            var t = new Temperature(12.3f);

            t.Value.Is(12.3f);
            t.DisplayValue.Is("12.30");
            t.DisplayValueWithUnit.Is("12.30��");
            t.DisplayValueWithUnitSpace.Is("12.30 ��");
        }

        [TestMethod]
        public void ValueObject�C���X�^���XEquals()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            t1.Equals(t2).IsTrue();
        }

        [TestMethod]
        public void ValueObject�C���X�^���X�������Z�q()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            (t1 == t2).IsTrue();
        }
    }
}