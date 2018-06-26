using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Desconcard.Data;

namespace Desconcard.Web.MVC.Models.login_Models
{
    public class Usuario
    {

        [DisplayName("Email: ")]
        public string Desc_email_usuario { get; set; }

        [DisplayName("Senha: ")]
        public string Desc_Senha { get; set; }


        public bool validaUsuarioLogin()
        {
            UsuarioData usuarioData = new UsuarioData();


            return usuarioData.beLogin(Desc_email_usuario,Desc_Senha);
        }


    }
}
