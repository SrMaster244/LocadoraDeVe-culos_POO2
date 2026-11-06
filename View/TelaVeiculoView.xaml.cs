using System.Windows;
using System.Windows.Controls;
using LocadoraDeVeículos.Model;

namespace LocadoraDeVeículos;

public partial class TelaVeiculoView : UserControl
{
    private readonly MainWindow mainWindow;

    public TelaVeiculoView(MainWindow mainWindow)
    {
        InitializeComponent();
        this.mainWindow = mainWindow;
        AtualizarVeiculos();
    }

    private void FiltroChanged(object sender, RoutedEventArgs e) => AtualizarVeiculos();

    private void AtualizarVeiculos()
    {
        if (grdVeiculos is null) return;
        var filtro = rdbCarros?.IsChecked == true ? "Carros" : rdbMotos?.IsChecked == true ? "Motos" : "Todos";
        grdVeiculos.ItemsSource = mainWindow.Controller.ObterVeiculos(filtro);
    }

    private void BtnConfirmarEscolha_Click(object sender, RoutedEventArgs e)
    {
        if (grdVeiculos.SelectedItem is not Veiculo veiculo)
        {
            MessageBox.Show("Selecione um veículo.", "Veículo", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        mainWindow.Controller.SelecionarVeiculo(veiculo);
        mainWindow.NavegarParaPagamento();
    }
}
