using Movit.DataTransfer.Estados.Response;

namespace Movit.DataTransfer.Cidades.Response
{
    public record CidadeResponse
    {
        public int Id { get; init; }
        public string Descricao { get; init; }
        public EstadoResponse Estado { get; init; }
    }
}