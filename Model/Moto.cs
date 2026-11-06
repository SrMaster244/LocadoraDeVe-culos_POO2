namespace LocadoraDeVeículos.Model
{
    public class Moto : Veiculo, ITarifa
    {
        public decimal Calcular(int dias)
        {
            return ValorDiaria * dias;
        }
    }
}
