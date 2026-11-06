using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeículos.Model
{
    internal interface ITarifa
    {
        public double Calcular(int dias);
            
    }
}
