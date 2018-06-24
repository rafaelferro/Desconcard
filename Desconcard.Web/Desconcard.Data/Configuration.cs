using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconcard.Data
{
   public class Configuration
    {
        public static string DBConection = ConfigurationManager.ConnectionStrings["Desconcard"].ConnectionString;
    }
}
