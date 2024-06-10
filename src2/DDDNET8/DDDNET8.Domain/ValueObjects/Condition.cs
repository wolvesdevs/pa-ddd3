namespace DDDNET8.Domain.ValueObjects
{
    public sealed class Condition(int value) : ValueObject<Condition>
    {
        #region フィールド

        /// <summary>
        /// 不明
        /// </summary>
        public static readonly Condition Unknown = new Condition(0);

        /// <summary>
        /// 晴れ
        /// </summary>
        public static readonly Condition Sunny = new Condition(1);

        /// <summary>
        /// 曇り
        /// </summary>
        public static readonly Condition Cloudy = new Condition(2);

        /// <summary>
        /// 雨
        /// </summary>
        public static readonly Condition Rainy = new Condition(3);

        #endregion

        #region プロパティ

        public int Value { get; } = value;
        public string DisplayValue => this switch
        {
            _ when this == Sunny => "晴れ",
            _ when this == Cloudy => "曇り",
            _ when this == Rainy => "雨",
            _ => "不明"
        };

        #endregion

        #region メソッド

        protected override bool EqualsCore(Condition other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static IList<Condition> ToList()
        {
            return new List<Condition>
            {
                Unknown,
                Sunny,
                Cloudy,
                Rainy
            };
        }

        #endregion
    }
}
