using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Repositorios.Filtros;
using Movit.Dominio.Genericos;

namespace Movit.Dominio.Cantinas.Repositorios
{
    public interface ICantinasRepositorio : IGenericoRepositorio<Cantina>
    {
        Task<IQueryable<Cantina>> FiltrarAsync(CantinaListarFiltro filtro);
    }
}