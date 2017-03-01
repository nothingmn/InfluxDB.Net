using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Core;
using InfluxDB.Core.Contracts;
using InfluxDB.REPL.Contracts;
using InfluxDB.REPL.Entities;

namespace InfluxDB.REPL.Commands
{
    [CommandDescriptor(Name = "connect", Description = "Connect to an instance of influxdb", Usage = "connect /h:<host> /u:<username> /p:<password>")]
    public class ConnectCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "h")]
        public string host { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "u")]
        public string username { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "p")]
        public string password { get; set; }

        public IConfiguration UpdatedConfiguration { get; set; }
        public IInfluxDb UpdatedClient { get; set; }

        public override Task Execute(IConfiguration configuration, IInfluxDb client, CancellationToken cancellationToken = default(CancellationToken))
        {
            Console.WriteLine($"Connecting to host ({username}) {host}");

            try
            {
                UpdatedClient = new InfluxDb(host, username, password);
                UpdatedConfiguration = new Configuration()
                {
                    Host = host,
                    Username = username,
                    Password = password
                };
                
                Console.WriteLine($"Connected, version:{UpdatedClient.GetClientVersion()}");
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error connecting to that instance.\n" + e);
            }

            return Task.FromResult(true);
        }
    }
}
