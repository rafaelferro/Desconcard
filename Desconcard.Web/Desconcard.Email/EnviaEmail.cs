using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Desconcard.Email
{
    public class EnviaEmail
    {
        private string Remetente;
        private string Destinatario;
        private string arquivo;
        private string Mensagem;
        private string Assunto;
        string user = "@outlook.com";
        string psw = "";


        public EnviaEmail(string rem, string dest, string arqui,string assunt)
        {

            Remetente = rem;
            Destinatario = dest;
            arquivo = arqui;
            Assunto = assunt;

        }

        public void Enviar()
        {
            try
            {
                // valida o email
                bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

                if (bValidaEmail == false)
                    throw new Exception("Email do destinatário inválido:" + Destinatario);

                // Cria uma mensagem
                MailMessage mensagemEmail = new MailMessage();
                mensagemEmail.From = new MailAddress(Remetente);
                mensagemEmail.To.Add(new MailAddress(Destinatario));
                // Obtem os anexos contidos em um arquivo arraylist e inclui na mensagem

                Attachment anexado = new Attachment(arquivo);
                mensagemEmail.Attachments.Add(anexado);


                SmtpClient client = new SmtpClient("smtp-mail.outlook.com",587);
                // Inclui as credenciais
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                credentials.UserName = user;
                credentials.Password = psw;
                client.Credentials = credentials;

                mensagemEmail.Subject = Assunto;
                mensagemEmail.Body = "Segue Boleto Referente ao Desconcard.";


                // envia a mensagem
                client.Send(mensagemEmail);

                Mensagem = "Mensagem enviada para " + Destinatario + " às " + DateTime.Now.ToString() + ".";
            }
            catch (Exception ex)
            {
                string erro = ex.InnerException.ToString();
                throw new Exception(ex.Message.ToString() + erro);
            }
        }

        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}

