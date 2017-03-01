using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Core.Contracts;
using InfluxDB.REPL.Contracts;

namespace InfluxDB.REPL.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public abstract Task Execute(IConfiguration configuration, IInfluxDb client, CancellationToken cancellationToken = default(CancellationToken));


        public bool IsConnected(IInfluxDb client)
        {
            if (client == null) return false;
            return true;
        }

    }
}
