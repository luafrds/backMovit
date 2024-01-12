using FluentNHibernate.Mapping;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Enumeradores;

namespace Movit.Infra.Usuarios.Mapeamentos
{
    public class UsuariosMap : ClassMap<Usuario>
    {
        public UsuariosMap()
        {
            Table("usuario");
            Id(x => x.Id, "id");
            Map(x => x.Email, "email");
            Map(x => x.Senha, "senha");
            Map(x => x.TipoUsuario, "tipousuario").CustomType<TipoUsuarioEnum>();
        }
    }
}