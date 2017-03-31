using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Logements.BusinessLogic
{
    static public class EmailFacilitator
    {
        public static void sendEmail(string destinataire, string sujet, string message)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("testlogement123@gmail.com", "t3st1234"),
                EnableSsl = true
            };
            smtp.Send("testlogement123@gmail.com", destinataire, sujet, message);
        }
    }
}
