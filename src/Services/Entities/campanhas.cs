namespace Services.Entities
{
    public class Campanha
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public List<Contato> Contatos { get; set; } = new();
    }
}
