namespace Movit.DataTransfer.Autenticacoes.Request
{
    public record CadastroRequest(string Email, string Senha, int TipoUsuario);
}