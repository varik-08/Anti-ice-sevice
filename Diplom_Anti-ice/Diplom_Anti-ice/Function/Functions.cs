using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace Diplom_Anti_ice.Controllers
{
    public class Functions
    {
        Model_Antiice ent = new Model_Antiice();

        public void sendEmail(Guid token)
        {
            foreach (var dev in ent.Device.ToList())
            {
                if (token == dev.Id)
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("varik0819961996@gmail.com");
                    mail.To.Add(new MailAddress("varik0819961996@gmail.com"));
                    mail.Subject = "Оповещение о гололёде!";
                    mail.Body = "Требуется помощь в устранении гололёда по координатам:\nШирота = "
                        + dev.Latitude + "\nДолгота = " + dev.Longitude;

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("varik0819961996@gmail.com".Split('@')[0], "aojhgtab");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);
                    mail.Dispose();

                }
            }
        }
    }
}