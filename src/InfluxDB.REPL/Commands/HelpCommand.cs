using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Core.Contracts;
using InfluxDB.REPL.Contracts;
using InfluxDB.REPL.Entities;

namespace InfluxDB.REPL.Commands
{
    [CommandDescriptor(Name = "help", Description = "Show this help.", Usage = "help")]
    public class HelpCommand : BaseCommand
    {
        public override Task Execute(IConfiguration configuration, IInfluxDb client, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var h in CommandFactory.GetHelp())
            {
                Console.WriteLine(h);
            }
            return Task.FromResult(true);
        }
    }
}
