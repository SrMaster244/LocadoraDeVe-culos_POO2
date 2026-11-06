namespace LocadoraDeVeículos.Model
{
    public class Carro : Veiculo, ITarifa
    {
        public decimal Calcular(int dias)
    {
            return ValorDiaria * dias;
    }
    }
}
