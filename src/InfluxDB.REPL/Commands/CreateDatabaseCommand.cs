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
    [CommandDescriptor(Name = "create database", Description = "Create a new database", Usage = "create database /n:<new database>")]
    public class CreateDatabaseCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "n")]
        public string name { get; set; }

        public override async Task Execute(IConfiguration configuration, IInfluxDb client, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!IsConnected(client))
            {
                Console.WriteLine("Not connected to any server.");
                return;

            }
            try
            {
                var result = await client.CreateDatabaseAsync(name);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error connecting to that instance.\n" + e);
            }

        }
    }
}