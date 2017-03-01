using System.Net.Http;

namespace InfluxDB.Core.Contracts
{
    internal interface IRequestContent
    {
        HttpContent GetContent();
    }
}