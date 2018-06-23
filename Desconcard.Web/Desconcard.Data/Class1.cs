using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconcard.Data
{
    public class Class1
    {
        public string DBConection = ConfigurationManager.ConnectionStrings["Desconcard"].ConnectionString;
    }
}
