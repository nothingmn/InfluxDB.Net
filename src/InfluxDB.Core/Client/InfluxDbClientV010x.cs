using InfluxDB.Core.Contracts;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Configuration;
using InfluxDB.Core.Infrastructure.Formatters;

namespace InfluxDB.Core.Client
{
    internal class InfluxDbClientV010x : InfluxDbClientBase
    {
        public InfluxDbClientV010x(InfluxDbClientConfiguration configuration) 
            : base(configuration)
        {
        }

        public override IFormatter GetFormatter()
        {
            return new FormatterV010x();
        }

        public override InfluxVersion GetVersion()
        {
            return InfluxVersion.v010x;
        }
    }
}