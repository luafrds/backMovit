using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Repositorios;
using Movit.Dominio.Cidades.Repositorios.Filtros;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Cidades.Repositorios
{
    public class CidadesRepositorio : GenericoRepositorio<Cidade>, ICidadesRepositorio
    {
        public CidadesRepositorio(ISession session) : base(session){}

        public async Task<IQueryable<Cidade>> FiltrarAsync(CidadeListarFiltro filtro)
        {
            IQueryable<Cidade> query = await QueryAsync();

            if (!string.IsNullOrWhiteSpace(filtro.Descricao))
            {
                query = query.Where(d => d.Descricao.Contains(filtro.Descricao));
            }

            return query;
        }
    }
}