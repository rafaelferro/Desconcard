using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconcard.Data
{
   public class EnderecoData
    {

        public string Desc_Rua = "Rua Sete De Setembro";
        public string Numero = "97";
        public string Desc_Bairro = "Jardin Itapevi";
        public CidadeData Cidade { get; set; }
        public string Cep_base = "06653";
        public string Cep_digito = "170";

        public EnderecoData()
        {
            //Cidade.Desc_Cidade = "Barueri";
        }

    }
}
