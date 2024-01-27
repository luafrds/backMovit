using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Repositorios.Filtros;
using Movit.Dominio.Genericos;

namespace Movit.Dominio.Cidades.Repositorios
{
    public interface ICidadesRepositorio : IGenericoRepositorio<Cidade>
    {
        Task<IQueryable<Cidade>> FiltrarAsync(CidadeListarFiltro filtro);
    }
}