using System;
using System.Data;
using Desconcard.Boleto;
using Desconcard.Email;

namespace Desconcard.Console.Geral
{
    internal class IntegraBoleto
    {
        string CaminhoPDF;

        public IntegraBoleto()
        {
        }

        internal void GeraBoleto(DataSet ds)
        {
            GerarBoleto gerarBoleto = new GerarBoleto();

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                if (row[0].ToString() != "")
                {
                    gerarBoleto.GeraBoleto(row);
                    CaminhoPDF = gerarBoleto.pathPDF;
                    EnviaEmail enviaEmail = new EnviaEmail("@outlook.com", row[12].ToString(), CaminhoPDF, "Combrança Desconcard");
                    enviaEmail.Enviar();

                }
            }


        }
    }
}