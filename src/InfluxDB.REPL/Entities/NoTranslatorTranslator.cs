using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxDB.REPL.Contracts;

namespace InfluxDB.REPL.Entities
{
    public class NoTranslatorTranslator : ITranslate
    {
        public string Translate(string key)
        {
            return key;
        }
    }
}
