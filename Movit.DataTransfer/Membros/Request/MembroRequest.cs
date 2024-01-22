using Movit.Dominio.Usuarios.Entidades;

namespace Movit.DataTransfer.Membros.Request
{
    public record MembroRequest(string NomeCompleto, string Email, DateTime DataNascimento, int IdUsuario);
}
