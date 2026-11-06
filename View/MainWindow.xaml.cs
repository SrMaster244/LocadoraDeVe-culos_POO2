using System.Windows;
using LocadoraDeVeículos.Controller;
using LocadoraDeVeículos.Data;

namespace LocadoraDeVeículos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Session = new LocacaoSession();
            Controller = new LocacaoController(Session, new LocadoraDbContext());
            NavegarParaCadastro();
        }

        public LocacaoSession Session { get; }
        public LocacaoController Controller { get; }

        public void NavegarParaCadastro() => navigationHost.Content = new TelaCadastroView(this);
        public void NavegarParaVeiculo() => navigationHost.Content = new TelaVeiculoView(this);
        public void NavegarParaPagamento() => navigationHost.Content = new TelaPagamentoView(this);
        public void NavegarParaSucesso(int idContrato) => navigationHost.Content = new TelaSucessoView(this, idContrato);
    }
}