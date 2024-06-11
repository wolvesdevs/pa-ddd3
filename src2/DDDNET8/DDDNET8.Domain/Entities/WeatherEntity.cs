using DDDNET8.Domain.ValueObjects;

namespace DDDNET8.Domain.Entities
{
    public sealed class WeatherEntity(int areaId, string areaName, DateTime dataDate, int condition, float temperature)
    {
        #region プロパティ

        public AreaId AreaId { get; } = new(areaId);
        public string AreaName { get; } = areaName;
        public DateTime DataDate { get; } = dataDate;
        public Condition Condition { get; } = new(condition);
        public Temperature Temperature { get; } = new(temperature);

        #endregion

        #region コンストラクタ

        public WeatherEntity(int areaId, DateTime dataDate, int condition, float temperature)
            : this(areaId, string.Empty, dataDate, condition, temperature)
        {
        }

        #endregion

        #region 未使用メソッド

        public bool IsExtremelyHot()
        {
            if (Condition == Condition.Sunny)
            {
                if (Temperature.Value > 35)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOK()
        {
            if (DataDate < DateTime.Now.AddMonths(-1))
            {
                if (Temperature.Value < 10)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
