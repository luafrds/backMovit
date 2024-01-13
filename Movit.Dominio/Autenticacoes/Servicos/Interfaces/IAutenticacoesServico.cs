using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Enumeradores;

namespace Movit.Dominio.Autenticacoes.Servicos.Interfaces
{
    public interface IAutenticacoesServico
    {
        Usuario ValidarCadastro(string email, string senha, int tipoUsuario);

        Usuario ValidarLogin(Usuario usuario, String senha);

        String GerarToken(Usuario usuario); 
    }
}