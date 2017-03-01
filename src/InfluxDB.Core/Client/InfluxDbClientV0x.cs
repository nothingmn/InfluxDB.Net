using InfluxDB.Core.Contracts;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Configuration;
using InfluxDB.Core.Infrastructure.Formatters;

namespace InfluxDB.Core.Client
{
    internal class InfluxDbClientV0x : InfluxDbClientBase
    {
        public InfluxDbClientV0x(InfluxDbClientConfiguration configuration)
            : base(configuration)
        {
        }

        public override IFormatter GetFormatter()
        {
            return new FormatterV0x();
        }

        public override InfluxVersion GetVersion()
        {
            return InfluxVersion.v0x;
        }
    }
}