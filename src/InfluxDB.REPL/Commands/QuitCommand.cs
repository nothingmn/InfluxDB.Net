using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Core.Contracts;
using InfluxDB.REPL.Contracts;

namespace InfluxDB.REPL.Commands
{
    [CommandDescriptor(Name = "quit", Description = "Quit the REPL", Usage = "quit")]
    public class QuitCommand : BaseCommand
    {

        public CancellationTokenSource CancellationTokenSource { get; set; }

        public override Task Execute(IConfiguration configuration, IInfluxDb client, CancellationToken cancellationToken = default(CancellationToken))
        {
            CancellationTokenSource.Cancel();
            return Task.FromResult(true);
        }
    }
}