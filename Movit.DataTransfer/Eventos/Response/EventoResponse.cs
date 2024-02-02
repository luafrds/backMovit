using Movit.DataTransfer.Cidades.Response;

namespace Movit.DataTransfer.Eventos.Response
{
    public record EventoResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataEvento { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public CidadeResponse Cidade { get; internal set; }
    }
}