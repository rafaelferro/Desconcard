using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Desconcard.Web.MVC.Models;

namespace Desconcard.Web.MVC.Models
{
    public class Endereco
    {
    public int ID_Endereco { get; set; }

    [DisplayName("Rua: ")]
    public string  Desc_Rua { get; set; }

    [DisplayName("Numero: ")]
    public string Numero { get; set; }

    [DisplayName("Bairro: ")]
    public string Desc_Bairro { get; set; }

    [DisplayName("Cidade: ")]
    public Cidade Cidade { get; set; }

    
    [DisplayName("Cep: ")]
    public char Cep_base { get; set; }
    
    [DisplayName("Digito: ")]
    public char Cep_digito { get; set; }

     [DisplayName("Cidade")]
     public Cidade cidade { get; set; }


    }
}
