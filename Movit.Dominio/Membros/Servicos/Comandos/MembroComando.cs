using Movit.Dominio.Membros.Enumeradores;
using Movit.Dominio.Usuarios.Entidades;

namespace Movit.Dominio.Membros.Servicos.Comandos
{
    public class MembroComando
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdUsuario { get; set; }
    }
}