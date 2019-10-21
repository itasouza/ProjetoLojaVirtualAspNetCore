using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("itasouza1@gmail.com", "ramati#01234");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2> Contato - Loja Virtual<h2>" +
                                            "<h2> Nome  - </br>{0}<br/>" +
                                            "<h2> E-mail  - </br>{1}<br/>" +
                                            "<h2> Texto  - </br>{2}<br/>" +
                                            "<br/> E-mail enviado automaticamente do site Loja",
                                             contato.Nome,
                                             contato.Email,
                                             contato.Texto
                                            );

            MailMessage message = new MailMessage();
            message.From = new MailAddress("itasouza1@gmail.com");
            message.To.Add("itasouza1@gmail.com");
            message.Subject = "Contato - Loja Virtual - E-mail" + contato.Email;
            message.Body = corpoMsg;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
