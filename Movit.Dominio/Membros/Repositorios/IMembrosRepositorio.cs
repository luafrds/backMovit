using Movit.Dominio.Genericos;
using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Repositorios.Filtros;

namespace Movit.Dominio.Membros.Repositorios
{
    public interface IMembrosRepositorio: IGenericoRepositorio<Membro>
    {
        Task<IQueryable<Membro>> FiltrarAsync(MembroListarFiltro filtro);
        Task<Membro> RecuperaUsuarioPorEmailAsync(string email);
    }
}