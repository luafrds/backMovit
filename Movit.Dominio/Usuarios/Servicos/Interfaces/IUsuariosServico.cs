using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Servicos.Comandos;

namespace Movit.Dominio.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosServico
    {
        Task<Usuario> ValidarAsync(int id);
        Task<Usuario> InserirAsync(UsuarioComando comando);
        Task<Usuario> EditarAsync(UsuarioComando comando);
    }
}