using InfluxDB.Core.Contracts;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Configuration;
using InfluxDB.Core.Infrastructure.Formatters;

namespace InfluxDB.Core.Client
{
    internal class InfluxDbClientV095 : InfluxDbClientBase
    {
        public InfluxDbClientV095(InfluxDbClientConfiguration configuration) 
            : base(configuration)
        {
        }

        public override IFormatter GetFormatter()
        {
            return new FormatterV095();
        }

        public override InfluxVersion GetVersion()
        {
            return InfluxVersion.v095;
        }
    }
}