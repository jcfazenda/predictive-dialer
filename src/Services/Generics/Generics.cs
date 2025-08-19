using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Generics
{
    public class Generics
    {
        public static bool IsEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\\.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$");

            return rg.IsMatch(email);
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
