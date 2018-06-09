using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Desconcard.Web.MVC.Models;

namespace Desconcard.Web.MVC.Controllers
{
    public class CadEstabalecimentoController : Controller
    {
        [HttpPost]
        public ActionResult Cadastrar(EstabelecimentoModelcs estabelecimento)
        {

            string nome = estabelecimento.Nm_Estabelecimento;


            return View();
        }
    }
}