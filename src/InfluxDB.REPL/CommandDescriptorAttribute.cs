using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfluxDB.REPL
{
    public class CommandDescriptorAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
    }
}
