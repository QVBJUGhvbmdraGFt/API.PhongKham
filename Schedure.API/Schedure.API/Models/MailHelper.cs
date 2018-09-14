using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Schedure.API.Models
{
    public static class MailHelper
    {
        //https://myaccount.google.com/lesssecureapps?pli=1
        public static void SendMail(string to, string subject, string body)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("cskh.phongkham@gmail.com", "passwork"),
                    EnableSsl = true,
                };
                var mail = new MailMessage("cskh.phongkham@gmail.com", to, subject, body)
                {
                    IsBodyHtml = true
                };

                client.Send(mail);
            }
            catch (Exception)
            {

            }
        }
    }
}