using Movit.Dominio.Genericos;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Repositorios.Filtros;

namespace Movit.Dominio.Usuarios.Repositorios
{
    public interface IUsuariosRepositorio : IGenericoRepositorio<Usuario>
    {
        Task<IQueryable<Usuario>> FiltrarAsync(UsuarioListarFiltro filtro);
        Task<Usuario> RecuperaUsuarioPorEmailAsync(string email);
    }
}