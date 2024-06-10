using DDDNET8.Domain.Helpers;

namespace DDDNET8.Domain.ValueObjects
{
    public sealed class Temperature(float value) : ValueObject<Temperature>
    {
        #region フィールド

        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        #endregion

        #region プロパティ

        public float Value { get; } = value;
        public string DisplayValue => Value.RoundString(DecimalPoint);
        public string DisplayValueWithUnit => Value.RoundString(DecimalPoint) + UnitName;
        public string DisplayValueWithUnitSpace => Value.RoundString(DecimalPoint) + " " + UnitName;

        #endregion

        #region メソッド

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion
    }
}
