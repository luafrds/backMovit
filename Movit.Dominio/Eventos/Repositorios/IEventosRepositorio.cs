using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Eventos.Repositorios.Filtros;
using Movit.Dominio.Genericos;

namespace Movit.Dominio.Eventos.Repositorios
{
    public interface IEventosRepositorio: IGenericoRepositorio<Evento>
    {
        Task<IQueryable<Evento>> FiltrarAsync(EventoListarFiltro filtro);
    }
}