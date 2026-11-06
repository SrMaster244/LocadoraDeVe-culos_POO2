namespace LocadoraDeVeículos.Model
{
    public class Contrato
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; } = null!;
        public DateTime DiaRetirada { get; set; }
        public DateTime DiaDevolucao { get; set; }
        public string MetodoPagamento { get; set; } = string.Empty;
        public decimal ValorFinal { get; set; }
    }
}
