﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Desconcard.Data;

namespace Desconcard.Geral
{
    class BoletoValores
    {

        public DataSet recValores()
        {
            DataSet valores = new DataSet();

            BoletosData boletos = new BoletosData();


            valores = boletos.recuperarValorBoletoPorusuario(2); 

            return valores;
        }

    }
}
