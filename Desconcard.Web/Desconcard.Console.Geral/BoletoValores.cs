using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Desconcard.Data;

namespace Desconcard.Console
{
    class BoletoValores
    {

        public DataSet recValores(string DB)
        {
            DataSet valores = new DataSet();

            BoletosData boletos = new BoletosData(DB);


            valores = boletos.recuperarValorBoletoPorusuario(2); 

            return valores;
        }

    }
}
