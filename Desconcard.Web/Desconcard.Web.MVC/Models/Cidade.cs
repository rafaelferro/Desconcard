using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Desconcard.Web.MVC.Models
{
    public class Cidade
    {

        public int  ID_Cidade { get; set; }

        [DisplayName("Cidade")]
        public string Desc_Cidade { get; set; }

        [DisplayName("Estado")]
        public Estado Estado { get; set; }

    }
}
