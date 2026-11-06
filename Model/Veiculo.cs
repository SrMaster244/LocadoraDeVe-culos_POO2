namespace LocadoraDeVeículos.Model
{
    public abstract class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public int Ano { get; set; }
        public decimal ValorDiaria { get; set; }
        public string Tipo => GetType().Name == nameof(Carro) ? "Carros" : "Motos";
    }
}
