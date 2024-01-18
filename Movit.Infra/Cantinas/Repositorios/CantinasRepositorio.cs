using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Repositorios;
using Movit.Dominio.Cantinas.Repositorios.Filtros;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Cantinas.Repositorios
{
    public class CantinasRepositorio: GenericoRepositorio<Cantina>, ICantinasRepositorio
    {
        public CantinasRepositorio(ISession session) : base(session) {}

        public async Task<IQueryable<Cantina>> FiltrarAsync(CantinaListarFiltro filtro)
        {
            IQueryable<Cantina> query = await QueryAsync();

            if (!string.IsNullOrWhiteSpace(filtro.NomeComida))
            {
                query = query.Where(d => d.NomeComida.Contains(filtro.NomeComida));
            }

            if(filtro.DataCantina != null)
            {
                query = query.Where(x => x.DataCantina == filtro.DataCantina);
            }

            return query;
        }
    }
}