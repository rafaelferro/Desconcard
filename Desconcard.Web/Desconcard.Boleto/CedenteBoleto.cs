using System;
using System.Data;

namespace Desconcard.Boleto
{
    internal class CedenteBoleto
    {
      private  DataSet dt = new DataSet();


        public string Id_Banco;
        public string Id_Agencia;
        public string Id_Conta;
        public string Digito_Conta;
        public string Operador_Conta;
        public string Conta_PF;
        public string CPFCNPJ;
        public string Beneficiario;
        public string carteira = "SIG14";
        public string logradouro;
        public string logradouroNumero;
        public string bairro;
        public string cidade;
        public string uf;
        public string cep;

       
        public void RecCedente()
        {
            try
            {
                Desconcard.Data.CedenteData cedenteData = new Data.CedenteData();
                dt = cedenteData.recContaCentente();

                foreach(DataRow row in dt.Tables[0].Rows)
                {
                    Id_Banco = row[0].ToString();
                    Id_Agencia = row[1].ToString();
                    Id_Conta = row[2].ToString();
                    Digito_Conta = row[3].ToString();
                    Operador_Conta = row[4].ToString();
                    Conta_PF = row[5].ToString();
                    CPFCNPJ = row[6].ToString();
                    Beneficiario = row[7].ToString();
                    logradouro = row[9].ToString();
                    logradouroNumero = row[10].ToString();
                    bairro = row[11].ToString();
                    cep = row[12].ToString() + "-" + row[13].ToString();
                    cidade = row[14].ToString();
                    uf = row[15].ToString();
                    return;

                }


            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}