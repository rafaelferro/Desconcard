using Desconcard.Data;
using System;

namespace Desconcard.Boleto
{
    public class BoletoControle
    {
       public  int NumeroBoletoControle;

        public void NumeroBoleto(int CLiente, decimal valor, int Mes, int Ano)
        {
            BoletosData boletosData = new BoletosData();
            NumeroBoletoControle = boletosData.NumeroBoletoControleData(CLiente, valor, Mes, Ano);
        }
    }
}