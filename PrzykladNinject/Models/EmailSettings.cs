using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzykladNinject.Models
{
    public class EmailSettings
    {
        public string MailToAddres = "zamowienia@przyklad.pl";
        public string MailFromAddress = "sklepsportowy@przyklad.pl";
        public bool UseSsl = true;
        public string Username = "UzytkownikSmtp";
        public string Password = "HasłoSmtp";
        public string ServerName = "smtp.przyklad.pl";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }
}