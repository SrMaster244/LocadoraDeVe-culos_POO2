using LocadoraDeVeículos.Data;
using LocadoraDeVeículos.Model;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeículos.Controller;

public sealed class LocacaoController
{
    private readonly LocacaoSession session;
    private readonly LocadoraDbContext db;

    public LocacaoController(LocacaoSession session, LocadoraDbContext db)
    {
        this.session = session;
        this.db = db;
    }

    public void CadastrarCliente(string tipoPessoa, string nome, string documento, string email, string cep, DateTime data)
    {
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(documento))
            throw new ArgumentException("Nome e CPF/CNPJ são obrigatórios.");

        session.Cliente = tipoPessoa == "Física"
            ? new PessoaFisica { Nome = nome, Documento = documento, Email = email, Cep = cep, DataNascimento = data }
            : new PessoaJuridica { Nome = nome, Documento = documento, Email = email, Cep = cep, DataFundacao = data };
    }

    public IReadOnlyList<Veiculo> ObterVeiculos(string filtro)
    {
        var veiculos = new List<Veiculo>
        {
            new Carro { Id = 1, Modelo = "Onix", Marca = "Chevrolet", Ano = 2024, ValorDiaria = 150 },
            new Carro { Id = 2, Modelo = "Civic", Marca = "Honda", Ano = 2023, ValorDiaria = 220 },
            new Moto { Id = 3, Modelo = "CG 160", Marca = "Honda", Ano = 2024, ValorDiaria = 85 },
            new Moto { Id = 4, Modelo = "Fazer 250", Marca = "Yamaha", Ano = 2023, ValorDiaria = 105 }
        };

        return filtro switch
        {
            "Carros" => veiculos.Where(v => v is Carro).ToList(),
            "Motos" => veiculos.Where(v => v is Moto).ToList(),
            _ => veiculos
        };
    }

    public void SelecionarVeiculo(Veiculo veiculo)
    {
        session.Veiculo = veiculo;
    }

    public decimal CalcularValor(DateTime retirada, DateTime devolucao, string metodoPagamento)
    {
        if (session.Veiculo is not ITarifa tarifa)
            return 0;

        var dias = Math.Max(1, (devolucao.Date - retirada.Date).Days);
        var valor = tarifa.Calcular(dias);
        return metodoPagamento == "Cartão" ? valor : valor;
    }

    public async Task<int> ConfirmarContratoAsync(DateTime retirada, DateTime devolucao, string metodoPagamento)
    {
        if (session.Cliente is null || session.Veiculo is null)
            throw new InvalidOperationException("Cliente e veículo devem ser selecionados.");
        if (devolucao.Date < retirada.Date)
            throw new ArgumentException("A devolução deve ser posterior à retirada.");

        var cliente = session.Cliente;
        var veiculoSelecionado = session.Veiculo;
        var veiculo = await db.Veiculos.FirstOrDefaultAsync(v =>
            v.Modelo == veiculoSelecionado.Modelo &&
            v.Marca == veiculoSelecionado.Marca &&
            v.Ano == veiculoSelecionado.Ano) ?? veiculoSelecionado;
        db.Clientes.Add(cliente);
        if (veiculo.Id == 0)
            db.Veiculos.Add(veiculo);

        var contrato = new Contrato
        {
            Cliente = cliente,
            Veiculo = veiculo,
            DiaRetirada = retirada.Date,
            DiaDevolucao = devolucao.Date,
            MetodoPagamento = metodoPagamento,
            ValorFinal = CalcularValor(retirada, devolucao, metodoPagamento)
        };
        db.Contratos.Add(contrato);
        await db.SaveChangesAsync();
        session.Contrato = contrato;
        return contrato.Id;
    }
}
