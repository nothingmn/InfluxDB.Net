using InfluxDB.Core.Models;

namespace InfluxDB.Core.Contracts
{
    public interface IFormatter
    {
        string GetLineTemplate();

        string PointToString(Point point);

        Serie PointToSerie(Point point);
    }
}