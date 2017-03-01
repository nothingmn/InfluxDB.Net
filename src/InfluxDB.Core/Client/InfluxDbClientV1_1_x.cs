using InfluxDB.Core.Contracts;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Configuration;
using InfluxDB.Core.Infrastructure.Formatters;

namespace InfluxDB.Core.Client
{
    internal class InfluxDbClientV1_1_x : InfluxDbClientBase
    {
        public InfluxDbClientV1_1_x(InfluxDbClientConfiguration configuration)
            : base(configuration)
        {
        }

        public override IFormatter GetFormatter()
        {
            return new FormatterV1_1_x();
        }

        public override InfluxVersion GetVersion()
        {
            return InfluxVersion.v1_1_x;
        }
    }
}