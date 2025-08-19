namespace Services.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Status { get; set; } = "Pendente"; // Pendente, Atendido, NãoAtende
        public int CampanhaId { get; set; }
    }
}
