using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Desconcard.Console.Geral
{
    class Program
    {
        static void Main(string[] args)
        {
            BoletoValores boletoValores = new BoletoValores();
            DataSet ds = new DataSet();

            ds = boletoValores.recValores();

            if (ds.Tables[0].Rows.Count > 0)
            {
                IntegraBoleto integra = new IntegraBoleto();
                integra.GeraBoleto(ds);
            }

        }
    }
}
