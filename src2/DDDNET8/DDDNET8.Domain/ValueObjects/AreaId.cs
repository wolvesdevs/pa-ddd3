namespace DDDNET8.Domain.ValueObjects
{
    public sealed class AreaId(int value) : ValueObject<AreaId>
    {
        #region プロパティ

        public int Value { get; } = value;
        public string DisplayValue => Value.ToString("0000");

        #endregion

        #region メソッド

        protected override bool EqualsCore(AreaId other)
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
