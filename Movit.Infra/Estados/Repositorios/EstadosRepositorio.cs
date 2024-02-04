using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Repositorios;
using Movit.Dominio.Estados.Repositorios.Filtros;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Estados.Repositorios
{
    public class EstadosRepositorio : GenericoRepositorio<Estado>, IEstadosRepositorio
    {
        public EstadosRepositorio(ISession session) : base(session) { }

        public async Task<IQueryable<Estado>> FiltrarAsync(EstadoListarFiltro filtro)
        {
            IQueryable<Estado> query = await QueryAsync();

            if (!string.IsNullOrWhiteSpace(filtro.Descricao))
            {
                query = query.Where(d => d.Descricao.Contains(filtro.Descricao));
            }

            if(filtro.Sigla != null)
            {
                query = query.Where(x => x.Sigla == filtro.Sigla);
            }

            return query;
        }

        
    }
}