using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Core.Contracts;

namespace InfluxDB.REPL.Contracts
{
    public interface ICommand
    {
        Task Execute(IConfiguration configuration, IInfluxDb client, CancellationToken cancellationToken = default(CancellationToken));
    }
}
