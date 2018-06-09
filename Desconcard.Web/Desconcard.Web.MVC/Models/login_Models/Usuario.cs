using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Desconcard.Web.MVC.Models.login_Models
{
    public class Usuario
    {
        [DisplayName("Email: ")]
        public string Desc_email_usuario { get; set; }

        [DisplayName("Senha: ")]
        public string Desc_Senha { get; set; }

    }
}
