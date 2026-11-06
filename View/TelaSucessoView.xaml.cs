using System.Windows;
using System.Windows.Controls;

namespace LocadoraDeVeículos;

public partial class TelaSucessoView : UserControl
{
    private readonly MainWindow mainWindow;

    public TelaSucessoView(MainWindow mainWindow, int idContrato)
    {
        InitializeComponent();
        this.mainWindow = mainWindow;
        lblMensagemSucesso.Text = $"Contrato N° {idContrato} registrado com sucesso!";
    }

    private void BtnNovaOperacao_Click(object sender, RoutedEventArgs e)
    {
        mainWindow.Session.Limpar();
        mainWindow.NavegarParaCadastro();
    }
}
