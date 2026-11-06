using System.Windows;
using System.Windows.Controls;
using LocadoraDeVeículos.Model;

namespace LocadoraDeVeículos;

public partial class TelaPagamentoView : UserControl
{
    private readonly MainWindow mainWindow;

    public TelaPagamentoView(MainWindow mainWindow)
    {
        InitializeComponent();
        this.mainWindow = mainWindow;
        var cliente = mainWindow.Session.Cliente;
        var veiculo = mainWindow.Session.Veiculo;
        lblNomeCliente.Text = cliente?.Nome ?? string.Empty;
        lblVeiculoSelecionado.Text = veiculo is null ? string.Empty : $"{veiculo.Marca} {veiculo.Modelo} ({veiculo.Ano})";
        lblValorDiaria.Text = veiculo?.ValorDiaria.ToString("C2") ?? "R$ 0,00";
        dtpRetirada.SelectedDate = DateTime.Today;
        dtpDevolucao.SelectedDate = DateTime.Today.AddDays(1);
        AtualizarValor();
    }

    private void PeriodoChanged(object sender, RoutedEventArgs e) => AtualizarValor();

    private void AtualizarValor()
    {
        if (dtpRetirada?.SelectedDate is not DateTime retirada || dtpDevolucao?.SelectedDate is not DateTime devolucao) return;
        var metodo = rdbPix?.IsChecked == true ? "Pix" : "Cartão";
        lblValorFinal.Text = mainWindow.Controller.CalcularValor(retirada, devolucao, metodo).ToString("C2");
    }

    private void BtnVoltar_Click(object sender, RoutedEventArgs e) => mainWindow.NavegarParaVeiculo();

    private async void BtnConfirmar_Click(object sender, RoutedEventArgs e)
    {
        if (dtpRetirada.SelectedDate is not DateTime retirada || dtpDevolucao.SelectedDate is not DateTime devolucao) return;
        try
        {
            var metodo = rdbPix.IsChecked == true ? "Pix" : "Cartão";
            var idContrato = await mainWindow.Controller.ConfirmarContratoAsync(retirada, devolucao, metodo);
            mainWindow.NavegarParaSucesso(idContrato);
        }
        catch (ArgumentException exception)
        {
            MessageBox.Show(exception.Message, "Pagamento", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
