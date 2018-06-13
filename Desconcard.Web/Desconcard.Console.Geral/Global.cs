using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Desconcard.Console.Geral
{
    class Global
    {
        public string DBConection = ConfigurationManager.ConnectionStrings["Desconcard"].ConnectionString;

    }
}
