using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Eventos.Repositorios;
using Movit.Dominio.Eventos.Repositorios.Filtros;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Eventos.Repositorios
{
    public class EventosRepositorio : GenericoRepositorio<Evento>, IEventosRepositorio
    {
        public EventosRepositorio(ISession session) : base(session)
        {
        }

        public async Task<IQueryable<Evento>> FiltrarAsync(EventoListarFiltro filtro)
        {
            IQueryable<Evento> query = await QueryAsync();

            if (!string.IsNullOrWhiteSpace(filtro.Titulo))
            {
                query = query.Where(d => d.Titulo.Contains(filtro.Titulo));
            }

            return query;
        }
    }
}