using Desconcard.Data;
using System;

namespace Desconcard.Boleto
{
    public class BoletoControle
    {
       public  int NumeroBoletoControle = 5;

        public void NumeroBoleto(int CLiente)
        {
            BoletosData boletosData = new BoletosData();
            NumeroBoletoControle = boletosData.NumeroBoletoControleData(CLiente);
        }
    }
}