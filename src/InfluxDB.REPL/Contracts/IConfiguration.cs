using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfluxDB.REPL.Contracts
{
    public interface IConfiguration
    {
        string Host { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
