using System;
using System.Net;
using System.Net.Mail;

namespace ProjetoTeste2.Domains.Utils
{
    public static class Utilities
    {
        /// <summary>
        /// Enviar Email
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="assunto"></param>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        public static bool EnviaEmail(string destinatario, string assunto, string mensagem)
        {
            try
            {
                // instanciando a classe Mail Message
                MailMessage mailMessage = new MailMessage();

                //Email do Remetente
                mailMessage.From = new MailAddress("ricardo.bolognesi@gmail.com");
                //Email.do Destinatário
                mailMessage.CC.Add(destinatario);
                //assunto do email
                mailMessage.Subject = assunto;
                //tipo do corpo do email
                mailMessage.IsBodyHtml = true;
                //corpo do email
                mailMessage.Body = mensagem;
                //configuração com porta
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",Convert.ToInt32(587));

                // configuração sem porta
                //SmtpClient smtpClient = new SmtpClient(UtilRsource.configSmtp);

                //Credencial de envio de email seguro quando o servidor exige authenticação
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("ricardo.bolognesi@gmail.com","rICK@dEBY");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public static string FormatarCNPJ(string cnpj)
        {
            cnpj = cnpj.Substring(0, 2) + "." + 
                   cnpj.Substring(2, 3) + "." + 
                   cnpj.Substring(5, 3) + "/" + 
                   cnpj.Substring(8,4) + "-" + 
                   cnpj.Substring(12, 2);
            return cnpj;
        }
    }
}
