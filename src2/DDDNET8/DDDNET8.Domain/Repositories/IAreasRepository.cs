using DDDNET8.Domain.Entities;

namespace DDDNET8.Domain.Repositories
{
    public interface IAreasRepository
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}
