using InfluxDB.Core.Contracts;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Configuration;
using InfluxDB.Core.Infrastructure.Formatters;

namespace InfluxDB.Core.Client
{
    internal class InfluxDbClientV011x : InfluxDbClientBase
    {
        public InfluxDbClientV011x(InfluxDbClientConfiguration configuration)
            : base(configuration)
        {
        }

        public override IFormatter GetFormatter()
        {
            return new FormatterV011x();
        }

        public override InfluxVersion GetVersion()
        {
            return InfluxVersion.v011x;
        }
    }
}