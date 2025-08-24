using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Services.Domain.Views.Input.Discadores;

namespace Services.Domain.Discadores.Twillio
{
    public class TwillioDial
    {
        private readonly string _accountSid = "ACfd0bb3331cfaf0dc8900ea62553b8c9f";
        private readonly string _authToken = "be2e9d5177d225073f56e8d1f5234e3f";
        private readonly string _fromNumber = "+18157832304";

        public TwillioDial()
        {
            TwilioClient.Init(_accountSid, _authToken);
        }

        public bool SendSMS(TwillioInput input)
        {
            if (input?.PhoneNumber == null) return false;

            var messageOptions = new CreateMessageOptions(new PhoneNumber(input.PhoneNumber))
            {
                From = new PhoneNumber(_fromNumber),
                Body = "Criatti Send SMS criatti@criatti.com"
            };

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine($"SMS SID: {message.Sid}, Status: {message.Status}");

            return true;
        }

        // ✅ Método para realizar chamada de voz
        public string? MakeCall(TwillioInput input)
        {
            if (input?.PhoneNumber == null) return null;

            try
            {
 
                var call = CallResource.Create(
                    twiml: new Twiml("<Response><Say voice=\"alice\" language=\"pt-BR\">Olá, esta é uma chamada de teste do Criatti Discador.</Say></Response>"),
                    to: new PhoneNumber(input.PhoneNumber),
                    from: new PhoneNumber(_fromNumber),
                    statusCallback: new Uri("http://localhost:7250/railway_criatti-replica/api/twillio/ReceiveStatus"), 
                    statusCallbackEvent: new List<string> { "initiated", "ringing", "completed", "busy", "failed", "no-answer" }
                );


                Console.WriteLine($"Call SID: {call.Sid}, Status: {call.Status}");
                return call.Sid; // agora retorna o SID
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar chamada: {ex.Message}");
                return null;
            }
        }

        // ✅ Método para consultar status da chamada pelo SID
        public object? GetCallStatus(string sid)
        {
            try
            {
                var call = CallResource.Fetch(pathSid: sid);

                var result = new
                {
                    call.Sid,
                    call.To,
                    call.From,
                    Status = call.Status?.ToString(),  // <- converte enum para string
                    call.StartTime,
                    call.EndTime,
                    call.Duration
                };

                Console.WriteLine($"Status SID: {call.Sid}, Status: {call.Status}, Duração: {call.Duration}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar status da chamada: {ex.Message}");
                return null;
            }
        }
    }
}
