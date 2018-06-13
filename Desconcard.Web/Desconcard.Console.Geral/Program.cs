using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;


namespace Desconcard.Console.Geral
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Global global = new Global();
            string conex = global.DBConection;

            BoletoValores boletoValores = new BoletoValores();
            DataSet ds = new DataSet();

            ds = boletoValores.recValores(conex);
            

            if (ds.Tables[0].Rows.Count > 0)
            {
                IntegraBoleto integra = new IntegraBoleto();
                integra.GeraBoleto(ds, conex);
            }

        }
    }
}
