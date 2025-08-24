using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Services.Generics
{
    public class Generics
    {
 
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public class Resposta
        {
            // Agora nunca será null porque inicializamos
            public List<Choice> choices { get; set; } = new();
            public List<Data> data { get; set; } = new();

            public class Choice
            {
                public string? text { get; set; }
            }

            public class Data
            {
                public string? url { get; set; }
            }
        }

    }
}
