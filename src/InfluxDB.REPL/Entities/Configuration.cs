using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxDB.REPL.Contracts;

namespace InfluxDB.REPL.Entities
{
    public class Configuration : IConfiguration
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
