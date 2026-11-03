using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeículos.Model
{
    internal class PessoaFisica : Cliente
    {
        private int CPF;

        public void CadastrarPF(int CPF, string nome)
        {
            this.CPF = CPF;
            this.Nome = nome;
        }
    }
}
