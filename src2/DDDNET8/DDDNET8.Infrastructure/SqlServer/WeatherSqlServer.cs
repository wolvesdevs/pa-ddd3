using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Repositories;
using DDDNET8.Domain.ValueObjects;
using Microsoft.Data.SqlClient;

namespace DDDNET8.Infrastructure.SqlServer
{
    public class WeatherSqlServer : IWeatherRepository
    {
        public WeatherEntity? GetLatest(int areaId)
        {
            string sql = @"
select top 1
    DataDate,
    Condition,
    Temperature
from Weather
where AreaId = @AreaId
order by DataDate desc
";

            return SqlServerHelper.QuerySingle(sql,
                new List<SqlParameter>
                {
                    new("@AreaId", areaId)
                }.ToArray(),
                reader =>
                {
                    return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                },
                null);
        }

        public IReadOnlyList<WeatherEntity> GetData()
        {
            string sql = @"
select
    W.AreaId,
    isnull(A.AreaName,'') as AreaName,
    W.DataDate,
    W.Condition,
    W.Temperature
from Weather as W
left join Areas as A
on W.AreaId = A.AreaId
";

            return SqlServerHelper.Query(sql,
                reader =>
                {
                    return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]) ?? "",
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                });
        }

        public void Save(WeatherEntity weather)
        {
            string insert = @"
insert into Weather
(AreaId,DataDate,Condition,Temperature)
values
(@AreaId,@DataDate,@Condition,@Temperature)
";

            string update = @"
update Weather
set Condition = @Condition,
    Temperature = @Temperature
where AreaId = @AreaId
and DataDate = @DataDate
";

            var args = new List<SqlParameter>
            {
                new("@AreaId", weather.AreaId.Value),
                new("@DataDate", weather.DataDate),
                new("@Condition", weather.Condition.Value),
                new("@Temperature", weather.Temperature.Value),
            };

            SqlServerHelper.Execute(insert, update, args.ToArray());
        }
    }
}
