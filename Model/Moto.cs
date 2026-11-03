using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeículos.Model
{
    internal class Moto : Veiculo , ITarifa
    {
        public double Calcular(int dias)
        {
            return this.precoDia * dias;
        }
    }
}
