using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Eventos.Servicos.Comandos;

namespace Movit.Dominio.Eventos.Servicos.Interfaces
{
    public interface IEventosServico
    {
        Task<Evento> ValidarAsync(int id);
        Task<Evento> InserirAsync(EventoComando comando);
        Task<Evento> EditarAsync(EventoComando comando);
    }
}