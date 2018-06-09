using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Desconcard.Web.MVC.Models
{
    public class Estado
    {
       public int ID_Estado { get; set; } 

        [DisplayName("Estado:")]
       public string Desc_Estado { get; set; }

        [DisplayName("UF:")]
       public string Desc_UF { get; set; }
    }
}
