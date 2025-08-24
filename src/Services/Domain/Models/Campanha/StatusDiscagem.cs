using System;
using Services.Domain.Models.Campanha;

namespace Services.Domain.Models.Campanha
{
    public class StatusDiscagem
    {
        public StatusDiscagem()
        {
        }

        public StatusDiscagem(long idStatus, string nomeStatus)
        {
            this.idStatus = idStatus;
            this.NomeStatus = nomeStatus;
        }

        public long idStatus { get; set; }
        public string NomeStatus { get; set; }   // Nome do status (Pendente, Bloqueado, CaixaPostal etc.)
        
        public ICollection<RegrasDiscagem>? Regras { get; set; }
    }
}
