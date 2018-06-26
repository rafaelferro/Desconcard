using Desconcard.Encrypt;
using Desconcard.Web.MVC.Models.login_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Desconcard.Web.MVC.Controllers
{
    public class LoginController : Controller
    {
        bool beLogin;
        string pass;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Login(Usuario usuario)
        {
            Criptografar cripitografar = new Criptografar();
            pass = cripitografar.HashValue(usuario.Desc_Senha);

            Usuario user = new Usuario();
            user.Desc_email_usuario = usuario.Desc_email_usuario;
            user.Desc_Senha = pass;

            beLogin = user.validaUsuarioLogin();

            if (!beLogin)
            {

            }

            Response.Redirect("~/CadEstabalecimento");
           
        }
    }
}