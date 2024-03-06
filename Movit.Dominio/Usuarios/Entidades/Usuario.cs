using System.Text.RegularExpressions;
using Movit.Dominio.Excecoes;
using Movit.Dominio.Usuarios.Enumeradores;

namespace Movit.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Senha { get; protected set; }
        public virtual TipoUsuarioEnum TipoUsuario { get; protected set; }

        public Usuario(string email, string senha, TipoUsuarioEnum tipoUsuario)
        {
            SetEmail(email);
            SetSenha(senha);
            SetTipoUsuario(tipoUsuario);
        }

        protected Usuario() { }

        public virtual void SetEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9]+@\S+\.com(\.\w+)?$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                throw new AtributoInvalidoExcecao("Email");
            }
            Email = email;
        }

        public virtual void SetSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha) || string.IsNullOrWhiteSpace(senha))
            {
                throw new AtributoObrigatorioExcecao("Senha");
            }
            if (senha.Length < 6 || senha.Length > 20)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("Senha", 6, 20);
            }
            // Verifica se a senha possui pelo menos uma letra maiúscula, uma letra minúscula,
            if (!senha.Any(c => char.IsUpper(c)))
            {
                throw new AtributoInvalidoExcecao("Senha");
            }
            if (!senha.Any(c => char.IsLower(c)))
            {
                throw new AtributoInvalidoExcecao("Senha");
            }
            // um caractere especial e um número
            if (!senha.Any(c => char.IsSymbol(c) || char.IsPunctuation(c)))
            {
                throw new AtributoInvalidoExcecao("Senha");
            }
            if (!senha.Any(c => char.IsNumber(c)))
            {
                throw new AtributoInvalidoExcecao("Senha");
            }
            Senha = senha;
        }

        public virtual void SetTipoUsuario(TipoUsuarioEnum tipoUsuario)
        {
            TipoUsuario = tipoUsuario;
        }

        public virtual void SetSenhaHash(string senhaHash)
        {
            Senha = senhaHash;
        }
    }
}