using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Repositorios;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Usuarios.Repositorios
{
    public class UsuariosRepositorio : GenericoRepositorio<Usuario>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(ISession session) : base(session) {}
    }
}