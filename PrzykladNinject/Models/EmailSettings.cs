using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzykladNinject.Models
{
    public class EmailSettings
    {
        public string MailToAddres = "servicersvp@onet.pl";
        public string MailFromAddress = "servicersvp@onet.pl";
        public bool UseSsl = true;
        public string Username = "servicersvp";
        public string Password = "!QAZ2wsx";
        public string ServerName = "smtp.poczta.onet.pl";
        public int ServerPort = 465;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }
}