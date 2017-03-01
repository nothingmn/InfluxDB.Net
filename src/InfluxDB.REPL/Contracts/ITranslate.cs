using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfluxDB.REPL.Contracts
{
    public interface ITranslate
    {
        string Translate(string key);
    }
}
