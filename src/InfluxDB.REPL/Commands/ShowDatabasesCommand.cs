using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Core;
using InfluxDB.Core.Contracts;
using InfluxDB.REPL.Contracts;
using InfluxDB.REPL.Entities;
using Newtonsoft.Json;

namespace InfluxDB.REPL.Commands
{
    [CommandDescriptor(Name = "show databases", Description = "Provides a list of databases", Usage = "show databases")]
    public class ShowDatabasesCommand : BaseCommand
    {
        public override async Task Execute(IConfiguration configuration, IInfluxDb client, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!IsConnected(client))
            {
                Console.WriteLine("Not connected to any server.");
                return;
            }
            try
            {
                var dbs = await client.ShowDatabasesAsync();
                Console.WriteLine(JsonConvert.SerializeObject(dbs));
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error connecting to that instance.\n" + e);
            }

        }
    }
}