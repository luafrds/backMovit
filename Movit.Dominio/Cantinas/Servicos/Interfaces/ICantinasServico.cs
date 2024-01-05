using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movit.Dominio.Cantinas.Entidades;

namespace Movit.Dominio.Cantinas.Servicos.Interfaces
{
    public interface ICantinasServico
    {
        Cantina Inserir (Cantina cantina);
        Cantina Instanciar (string nomeComida, decimal valor, int quantidade);
        Cantina Editar (string nomeComida, decimal valor, int quantidade);

    }
}