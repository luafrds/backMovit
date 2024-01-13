using Movit.Dominio.Usuarios.Enumeradores;

namespace Movit.Dominio.Usuarios.Servicos.Comandos
{
    public class UsuarioComando
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}