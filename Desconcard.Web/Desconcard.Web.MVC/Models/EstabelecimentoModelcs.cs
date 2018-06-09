using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Desconcard.Web.MVC.Models.login_Models;

namespace Desconcard.Web.MVC.Models
{
    public class EstabelecimentoModelcs
    {
        public int Id_estabelecimento { get; set; }

        [DisplayName("Nome: ")]
        public string Nm_Estabelecimento { get; set; }

        [DisplayName("CNPJ: ")]
        public string Cnpj_Estabelecimento_Base { get; set; }

        [DisplayName(" / ")]
        public string Cnpj_Estabelecimento_barra { get; set; }

        [DisplayName(" - ")]
        public string Cnpj_Estabelecimento_digito { get; set; }

        [DisplayName("Endereço:  ")]
        public Endereco Endereco_Estabelecimento { get; set; }

        [DisplayName("Usuario")]
        public Usuario usuario { get; set; }


       

    }
}
