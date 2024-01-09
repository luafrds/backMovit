using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Servicos.Comandos;

namespace Movit.Dominio.Cantinas.Servicos.Interfaces
{
    public interface ICantinasServico
    {
        Task<Cantina> ValidarAsync(int id);
        Task<Cantina> InserirAsync (CantinaComando comando);
        Task<Cantina> EditarAsync (CantinaComando comando);

    }
}