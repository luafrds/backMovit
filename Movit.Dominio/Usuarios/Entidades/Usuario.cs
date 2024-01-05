using Movit.Dominio.Excecoes;
using Movit.Dominio.Usuarios.Enumeradores;

namespace Movit.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public int Id { get;  protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }

        public Usuario(string email, string senha, TipoUsuarioEnum tipoUsuario)
        {
            SetEmail(email);
            SetSenha(senha);
            SetTipoUsuario(tipoUsuario);
        }

        public virtual void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new RegraDeNegocioExcecao("O email não pode vir vazio ou com espaço em branco");
            }
            Email = email;
        }

        public virtual void SetSenha(string senha)
        {
            if(string.IsNullOrWhiteSpace(senha))
            {
                throw new RegraDeNegocioExcecao("O senha não pode vir vazio ou com espaço em branco");
            }
            Senha = senha;
        }

        public virtual void SetTipoUsuario(TipoUsuarioEnum tipoUsuario)
        {
            TipoUsuario = tipoUsuario;
        }

    }
}