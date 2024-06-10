using DDDNET8.Domain.Entities;
using DDDNET8.Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace DDDNET8.Infrastructure.SqlServer
{
    public sealed class AreasSqlServer : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = @"
select 
    AreaId,
    AreaName
from Areas
";

            return SqlServerHelper.Query(sql,
                reader =>
                {
                    return new AreaEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]) ?? "");
                });
        }
    }
}
