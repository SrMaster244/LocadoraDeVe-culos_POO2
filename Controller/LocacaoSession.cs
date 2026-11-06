using LocadoraDeVeículos.Model;

namespace LocadoraDeVeículos.Controller;

public sealed class LocacaoSession
{
    public Cliente? Cliente { get; set; }
    public Veiculo? Veiculo { get; set; }
    public Contrato? Contrato { get; set; }

    public void Limpar()
    {
        Cliente = null;
        Veiculo = null;
        Contrato = null;
    }
}
