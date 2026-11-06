using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeículos.Model
{
    internal class PessoaJuridica : Cliente
    {
        private int CNPJ;

        public void CadastrarPJ(int cnpj, string nome) { 
            this.CNPJ = cnpj;
            this.Nome = nome;
        }
    }
}
