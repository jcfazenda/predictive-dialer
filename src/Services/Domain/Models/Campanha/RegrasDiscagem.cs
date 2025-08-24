using System;
using Services.Domain.Models.Campanha;

namespace Services.Domain.Models.Campanha
{
    public class RegrasDiscagem
    {
        public RegrasDiscagem()
        {
        }

        public RegrasDiscagem(long idRegra, long idStatus, int quantidadeTentativas, int intervaloMinutos)
        {
            this.idRegra = idRegra;
            this.idStatus = idStatus;
            this.QuantidadeTentativas = quantidadeTentativas;
            this.IntervaloMinutos = intervaloMinutos;
        }

        public long idRegra { get; set; }
        public long idStatus { get; set; }   // FK para StatusDiscagem
        public int QuantidadeTentativas { get; set; }
        public int IntervaloMinutos { get; set; }

        public ICollection<RegrasDiscagem>? Regras { get; set; }
    }
}
