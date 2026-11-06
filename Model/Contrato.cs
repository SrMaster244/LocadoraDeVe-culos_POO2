using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeículos.Model
{
    internal class Contrato 
    {
        public int ClienteID;
        public Cliente cliente;

        public int VeiculoID;
        public Veiculo veiculo;

        public List<Pagamento> Pagamentos {  get; set; }

    }
}
