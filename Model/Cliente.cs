namespace LocadoraDeVeículos.Model
{
    public abstract class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; } = DateTime.Now;
    }
}
