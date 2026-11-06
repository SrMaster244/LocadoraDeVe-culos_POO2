using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeículos.Model
{
    internal class Veiculo
    {
        private int renavam;
        public string marca;
        public string nome;
        public float precoDia; // preço por dia de locação

        public List<Contrato> Contratos {  get; set; }

        public void Veiculo1(int renavam, string marca, string nome, float precoDia)
        {
            this.renavam = renavam;
            this.marca = marca;
            this.nome = nome;
            this.precoDia = precoDia;
        }

    }
}
