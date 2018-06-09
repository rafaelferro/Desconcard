﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Boleto2Net;
using System.IO;
using System.Web;
using System.Web.UI;
using Desconcard.Data;

namespace Desconcard.Boleto
{
    public class GerarBoleto
    {

        Boletos boletos = null;

        public GerarBoleto()
        {
            boletos = new Boletos();

            //Cabeçalho
            boletos.Banco = Banco.Instancia(104);
            boletos.Banco.Cedente = new Cedente
            {
                CPFCNPJ = "",
                Nome = "",
                Observacoes = string.Empty,
                ContaBancaria = new ContaBancaria
                {
                    Agencia = "",
                    DigitoAgencia = "",
                    OperacaoConta = "",
                    Conta = "",
                    DigitoConta = "",
                    CarteiraPadrao = "",
                    VariacaoCarteiraPadrao = "",
                    TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
                    TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
                    TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa,
                    TipoDocumento = TipoDocumento.Tradicional
                },
                Codigo = "10",
                CodigoDV = "0",
                CodigoTransmissao = string.Empty,
                Endereco = new Boleto2Net.Endereco
                {
                    LogradouroEndereco = "Rua Sete De Setembro",
                    LogradouroNumero = "97",
                    LogradouroComplemento = "",
                    Bairro = "Jardin Itapevi",
                    Cidade = "Itapevi",
                    UF = "SP",
                    CEP = "06653-170"
                }
            };

            boletos.Banco.FormataCedente();
        }


        public void GeraBoleto(DataRow row)
        {
            //CedenteData cedente = new CedenteData();
            //EnderecoData endereco = new EnderecoData();
            //Títulos

            var boleto = new Boleto2Net.Boleto(boletos.Banco);
            boleto.Sacado = new Sacado
            {
                CPFCNPJ = row[3].ToString(),
                Nome = row[1].ToString() + " " + row[2].ToString(),
                Observacoes = string.Empty,
                Endereco = new Boleto2Net.Endereco
                {
                    LogradouroEndereco = row[5].ToString(),
                    LogradouroNumero = row[7].ToString(),
                    LogradouroComplemento = "",
                    Bairro = row[6].ToString(),
                    Cidade = row[10].ToString(),
                    UF = row[11].ToString(),
                    CEP = row[8].ToString() + row[9].ToString()
                }
            };

            boleto.CodigoOcorrencia = "01"; //Registrar remessa
            boleto.DescricaoOcorrencia = "Remessa Registrar";

            boleto.NumeroDocumento = "04";
            boleto.NumeroControleParticipante = "04";
            boleto.NossoNumero = "401";

            boleto.DataEmissao = DateTime.Today;
            boleto.DataVencimento = boleto.DataEmissao.AddDays(10);
            boleto.ValorTitulo = Convert.ToDecimal(row[4].ToString());
            boleto.Aceite = "N";
            boleto.EspecieDocumento = TipoEspecieDocumento.DM;

            //boleto.DataDesconto = DateTime.Today;
            //boleto.ValorDesconto = 0;
            decimal ValorMulta = Convert.ToDecimal(row[4])/10;
            decimal precMulta = 02;
            if (ValorMulta > 0)
            {
                boleto.DataMulta = boleto.DataVencimento.AddDays(1);
                boleto.PercentualMulta = precMulta;
                boleto.ValorMulta = boleto.ValorTitulo * boleto.PercentualMulta / 100;

                boleto.MensagemInstrucoesCaixa = $"Cobrar Multa de {boleto.ValorMulta} após o vencimento.";
            }

            if (precMulta > 0)
            {
                boleto.DataJuros = boleto.DataVencimento.AddDays(1);
                boleto.PercentualJurosDia = (precMulta / 30);
                boleto.ValorJurosDia = boleto.ValorTitulo * boleto.PercentualJurosDia / 100;

                string instrucao = $"Cobrar juros de {boleto.PercentualJurosDia} por dia de atraso";
                if (string.IsNullOrEmpty(boleto.MensagemInstrucoesCaixa))
                    boleto.MensagemInstrucoesCaixa = instrucao;
                else
                    boleto.MensagemInstrucoesCaixa += Environment.NewLine + instrucao;
            }

            /*
            boleto.CodigoInstrucao1 = string.Empty;
            boleto.ComplementoInstrucao1 = string.Empty;

            boleto.CodigoInstrucao2 = string.Empty;
            boleto.ComplementoInstrucao2 = string.Empty;

            boleto.CodigoInstrucao3 = string.Empty;
            boleto.ComplementoInstrucao3 = string.Empty;                
            */

            boleto.CodigoProtesto = TipoCodigoProtesto.NaoProtestar;
            boleto.DiasProtesto = 10;

            boleto.CodigoBaixaDevolucao = TipoCodigoBaixaDevolucao.NaoBaixarNaoDevolver;
            boleto.DiasBaixaDevolucao = 0;

            boleto.ValidarDados();
            boletos.Add(boleto);



            //Gerar Remessa
            var stream = new MemoryStream();
            var remessa = new ArquivoRemessa(boletos.Banco, TipoArquivo.CNAB400, 1);
            remessa.GerarArquivoRemessa(boletos, stream);


            //Gerar boletos - aqui eu gravo os arquivos um a um porque mando via e-mail.
            foreach (var boleto1 in boletos)
            {
                var boletoBancario = new BoletoBancario() { Boleto = boleto1 };
                var pdf = boletoBancario.MontaBytesPDF(false);
                string pathPDF = @"C:\Teste\" + boleto.NumeroControleParticipante + ".pdf";
                File.WriteAllBytes(pathPDF, pdf);
            }
        }

    }
}