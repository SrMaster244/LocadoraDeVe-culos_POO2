using System.Windows;
using System.Windows.Controls;

namespace LocadoraDeVeículos;

public partial class TelaCadastroView : UserControl
{
    private readonly MainWindow mainWindow;

    public TelaCadastroView(MainWindow mainWindow)
    {
        InitializeComponent();
        this.mainWindow = mainWindow;
        dtpData.SelectedDate = DateTime.Today;
    }

    private void TipoPessoaChanged(object sender, RoutedEventArgs e)
    {
        var pessoaFisica = rdbPessoaFisica?.IsChecked == true;
        if (lblDocumento is null) return;
        lblDocumento.Content = pessoaFisica ? "CPF:" : "CNPJ:";
        lblData.Content = pessoaFisica ? "Data de Nascimento:" : "Data de Fundação:";
    }

    private void BtnCadastro_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            mainWindow.Controller.CadastrarCliente(
                rdbPessoaFisica.IsChecked == true ? "Física" : "Jurídica",
                txtNome.Text, txtDocumento.Text, txtEmail.Text, txtCep.Text,
                dtpData.SelectedDate ?? DateTime.Today);
            mainWindow.NavegarParaVeiculo();
        }
        catch (ArgumentException exception)
        {
            MessageBox.Show(exception.Message, "Cadastro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
