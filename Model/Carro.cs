using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeículos.Model
{
    internal class Carro : Veiculo , ITarifa
    {
        public double Calcular(int dias)
    {
            return this.precoDia * dias; 
    }
   
    }
}
