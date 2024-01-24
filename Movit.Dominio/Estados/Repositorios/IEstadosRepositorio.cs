using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Repositorios.Filtros;
using Movit.Dominio.Genericos;

namespace Movit.Dominio.Estados.Repositorios
{
    public interface IEstadosRepositorio : IGenericoRepositorio<Estado>
    {
        Task<IQueryable<Estado>> FiltrarAsync(EstadoListarFiltro filtro);
    }
}