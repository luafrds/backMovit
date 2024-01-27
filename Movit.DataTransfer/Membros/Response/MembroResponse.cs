using Movit.DataTransfer.Usuarios.Response;

namespace Movit.DataTransfer.Membros.Response
{
    public record MembroResponse
    {
        public int Id { get; init; }
        public string NomeCompleto { get; init; }
        public DateTime DataNascimento { get; init; }
        public string Email { get; init; }
        public int SituacaoMembro{ get; init; }
        public UsuarioResponse Usuario { get; init; }
    }
}