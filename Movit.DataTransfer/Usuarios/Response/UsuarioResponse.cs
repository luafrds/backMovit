namespace Movit.DataTransfer.Usuarios.Response
{
    public record UsuarioResponse
    {
        public int Id { get; init; }
        public string Email { get; init; }
        public int TipoUsuario { get; init; }
    }
}