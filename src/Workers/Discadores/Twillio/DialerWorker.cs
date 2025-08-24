using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Services.Domain.Views.Input.Discadores;

namespace Workers.Discadores.Twillio
{
    public class DialerWorker
    {
        private readonly string _accountSid = "ACfd0bb3331cfaf0dc8900ea62553b8c9f";
        private readonly string _authToken = "be2e9d5177d225073f56e8d1f5234e3f";
        private readonly string _fromNumber = "+18157832304";

        public DialerWorker()
        {
            TwilioClient.Init(_accountSid, _authToken);
        }

        public bool ExecuteDial(TwillioInput input)
        {
            if (input?.PhoneNumber == null) return false;

            var messageOptions = new CreateMessageOptions(new PhoneNumber(input.PhoneNumber))
            {
                From = new PhoneNumber(_fromNumber),
                Body = "Teste de discagem via API"
            };

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine($"SID: {message.Sid}, Status: {message.Status}");

            return true;
        }
    }
}
