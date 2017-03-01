using InfluxDB.Core.Contracts;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Configuration;
using InfluxDB.Core.Infrastructure.Formatters;

namespace InfluxDB.Core.Client
{
    internal class InfluxDbClientV012x : InfluxDbClientBase
    {
        public InfluxDbClientV012x(InfluxDbClientConfiguration configuration)
            : base(configuration)
        {
        }

        public override IFormatter GetFormatter()
        {
            return new FormatterV012x();
        }

        public override InfluxVersion GetVersion()
        {
            return InfluxVersion.v012x;
        }
    }
}