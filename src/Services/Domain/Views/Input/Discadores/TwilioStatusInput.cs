 

namespace Services.Domain.Views.Input.Discadores
{
    public class TwilioStatusInput
    { 
            public string CallSid { get; set; } = string.Empty; 
            public string CallStatus { get; set; }= string.Empty; 
 
            public string To { get; set; }= string.Empty; 
 
            public string From { get; set; }= string.Empty; 
    }
}

