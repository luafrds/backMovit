using Movit.Dominio.Excecoes;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Repositorios;
using Movit.Dominio.Usuarios.Servicos.Comandos;
using Movit.Dominio.Usuarios.Servicos.Interfaces;

namespace Movit.Dominio.Usuarios.Servicos
{
    public class UsuariosServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;

        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio)
        {
            this.usuariosRepositorio = usuariosRepositorio;
        }

        public async Task<Usuario> EditarAsync(UsuarioComando comando)
        {
            Usuario usuario = await ValidarAsync(comando.Id);
            usuario.SetEmail(comando.Email);
            usuario.SetSenha(comando.Senha);
            usuario.SetTipoUsuario(comando.TipoUsuario);
            await usuariosRepositorio.EditarAsync(usuario);
            return usuario;
        }

        public async Task<Usuario> InserirAsync(UsuarioComando comando)
        {
            Usuario usuario = new(comando.Email, comando.Senha, comando.TipoUsuario);
            await usuariosRepositorio.InserirAsync(usuario);
            return usuario;
        }

        public async Task<Usuario> ValidarAsync(int id)
        {
           Usuario usuario = await usuariosRepositorio.RecuperarAsync(id);
           if(usuario == null)
           throw new RegraDeNegocioExcecao("Usuario não encontrado");

           return usuario;
        }
    }
}