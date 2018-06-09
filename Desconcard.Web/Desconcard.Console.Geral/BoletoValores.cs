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

        public DataSet recValores()
        {
            DataSet valores = new DataSet();

            BoletosData boletos = new BoletosData();


            valores = boletos.recuperarValorBoletoPorusuario(1); 

            return valores;
        }

    }
}
