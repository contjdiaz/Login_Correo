using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

/// <summary>
/// Descripción breve de Enviar
/// </summary>
public class Enviar
{
    
    public static bool teste;
    public object email(string para, string asunto, string messages, string anexo)
    {
        teste = false;
        SmtpClient smtp = new SmtpClient();
        MailMessage mail = new MailMessage();
        Attachment anexar = new Attachment(anexo);
        mail.Attachments.Add(anexar);

        smtp.Host = "smtp.live.com";
        smtp.Port = 25;
        smtp.EnableSsl = true;

        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("dbtatis06@hotmail.com", "tatis2007");
        mail.From = new MailAddress("dbtatis06@hotmail.com");

        if (!string.IsNullOrWhiteSpace(para))
        {
            mail.To.Add(new MailAddress(para));
            teste = true;
        }
        else
        {
            teste = false;
        }

        mail.Subject = asunto;
        mail.Body = messages;

        smtp.Send(mail);
        return teste;
    

    }
}