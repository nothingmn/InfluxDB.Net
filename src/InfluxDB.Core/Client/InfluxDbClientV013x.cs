using InfluxDB.Core.Contracts;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Configuration;
using InfluxDB.Core.Infrastructure.Formatters;

namespace InfluxDB.Core.Client
{
    internal class InfluxDbClientV013x : InfluxDbClientBase
    {
        public InfluxDbClientV013x(InfluxDbClientConfiguration configuration)
            : base(configuration)
        {
        }

        public override IFormatter GetFormatter()
        {
            return new FormatterV013x();
        }

        public override InfluxVersion GetVersion()
        {
            return InfluxVersion.v013x;
        }
    }
}