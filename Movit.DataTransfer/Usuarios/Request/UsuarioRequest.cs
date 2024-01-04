namespace Movit.DataTransfer.Usuarios.Request
{
    public record UsuarioRequest(string Email, string Senha, int TipoUsuario);
}