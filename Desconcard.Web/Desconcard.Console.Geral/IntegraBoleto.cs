using System;
using System.Data;
using Desconcard.Boleto;

namespace Desconcard.Console.Geral
{
    internal class IntegraBoleto
    {
        public IntegraBoleto()
        {
        }

        internal void GeraBoleto(DataSet ds, string conex)
        {
            GerarBoleto gerarBoleto = new GerarBoleto(conex);

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                if (row[0].ToString() != "")
                {
                    gerarBoleto.GeraBoleto(row);
                }
            }


        }
    }
}