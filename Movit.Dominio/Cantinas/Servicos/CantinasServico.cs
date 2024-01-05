using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Servicos.Interfaces;

namespace Movit.Dominio.Cantinas.Servicos
{
    public class CantinasServico : ICantinasServico
    {
        public Cantina Editar(string nomeComida, decimal valor, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Cantina Inserir(Cantina cantina)
        {
            throw new NotImplementedException();
        }

        public Cantina Instanciar(string nomeComida, decimal valor, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}