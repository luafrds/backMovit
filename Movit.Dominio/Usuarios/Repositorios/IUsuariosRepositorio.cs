using Movit.Dominio.Genericos;
using Movit.Dominio.Usuarios.Entidades;

namespace Movit.Dominio.Usuarios.Repositorios
{
    public interface IUsuariosRepositorio : IGenericoRepositorio<Usuario>
    {
        Task<Usuario> RecuperaUsuarioPorEmailAsync(string email);
    }
}