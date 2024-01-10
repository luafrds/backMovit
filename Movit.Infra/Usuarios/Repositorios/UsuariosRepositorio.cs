using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Enumeradores;
using Movit.Dominio.Usuarios.Repositorios;
using Movit.Dominio.Usuarios.Repositorios.Filtros;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Usuarios.Repositorios
{
    public class UsuariosRepositorio : GenericoRepositorio<Usuario>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(ISession session) : base(session) { }

        public async Task<IQueryable<Usuario>> FiltrarAsync(UsuarioListarFiltro filtro)
        {
            IQueryable<Usuario> query = await QueryAsync();

            if (!string.IsNullOrEmpty(filtro.Email))
            {
                query = query.Where(d => d.Email.Contains(filtro.Email));
            }

            switch (filtro.TipoUsuario)
            {
                case 1:
                    query = query.Where(u => u.TipoUsuario == TipoUsuarioEnum.Administrador);
                    break;
                case 2:
                    query = query.Where(u => u.TipoUsuario == TipoUsuarioEnum.Integrante);
                    break;
                case 3:
                    query = query.Where(u => u.TipoUsuario == TipoUsuarioEnum.Lider);
                    break;
            }

            return query;
        }

        public async Task<Usuario> RecuperaUsuarioPorEmailAsync(string email)
        {
            Usuario usuario = await session.QueryOver<Usuario>()
                                            .Where(u => u.Email == email)
                                            .SingleOrDefaultAsync();
            return usuario;
        }
    }
}
