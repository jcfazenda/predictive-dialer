 

namespace Services.Domain.Views.Input.Discadores
{
    public class TwillioInput
    {
        public string PhoneNumber { get; set; } = string.Empty; 
        public string NumberFrom { get; set; } = string.Empty; 
        public string Sid { get; set; } = string.Empty; 
        public string StatusDial { get; set; } = string.Empty; 
    }
}

