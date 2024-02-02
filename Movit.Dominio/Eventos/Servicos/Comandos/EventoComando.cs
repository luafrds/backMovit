using Movit.Dominio.Cidades.Entidades;

namespace Movit.Dominio.Eventos.Servicos.Comandos
{
    public class EventoComando
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataEvento { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int IdCidade { get; internal set; }
    }
}