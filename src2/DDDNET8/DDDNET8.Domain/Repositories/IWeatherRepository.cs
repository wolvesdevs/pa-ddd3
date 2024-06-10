using DDDNET8.Domain.Entities;
using System.Collections.Generic;

namespace DDDNET8.Domain.Repositories
{
    public interface IWeatherRepository
    {
        WeatherEntity? GetLatest(int areaId);
        IReadOnlyList<WeatherEntity> GetData();
        void Save(WeatherEntity weather);
    }
}
