using System.Text.RegularExpressions;
using Movit.Dominio.Excecoes;
using Movit.Dominio.Membros.Enumeradores;
using Movit.Dominio.Usuarios.Entidades;

namespace Movit.Dominio.Membros.Entidades
{
    public class Membro
    {
        public virtual int Id { get; protected set; }
        public virtual string NomeCompleto { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual DateTime DataNascimento { get; protected set; }
        public virtual SituacaoMembroEnum SituacaoMembro{ get; protected set; }
        public virtual Usuario Usuario { get; protected set; }
        
        public Membro(string nomeCompleto, string email, DateTime dataNascimento, Usuario usuario)
        {
            SetNomeCompleto(nomeCompleto);
            SetEmail(email);
            SetDataNascimento(dataNascimento);
            SetSituacaoMembro(SituacaoMembroEnum.Ativo);
            SetUsuario(usuario);
        }

        protected Membro() {}

        public virtual void SetNomeCompleto(string nomeCompleto)
        {
            if (string.IsNullOrWhiteSpace(nomeCompleto))
                throw new AtributoObrigatorioExcecao("Nome");

            if (nomeCompleto.Length < 4 || nomeCompleto.Length > 100)
                throw new TamanhoDeAtributoInvalidoExcecao("Nome", 5, 100);

            NomeCompleto = nomeCompleto;
        }
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
        public virtual void SetDataNascimento(DateTime dataNascimento)
        {     
            DataNascimento = dataNascimento;  
        }
        public virtual void SetSituacaoMembro(SituacaoMembroEnum situacaoMembro)
        {
            SituacaoMembro = situacaoMembro;
        }
        public virtual void SetUsuario(Usuario usuario)
        {
            Usuario = usuario ?? throw new AtributoObrigatorioExcecao("Usuario");
        }
    }
}