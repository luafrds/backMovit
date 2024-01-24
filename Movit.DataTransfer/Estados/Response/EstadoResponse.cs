namespace Movit.DataTransfer.Estados.Response
{
    public record EstadoResponse
    {
        public int Id { get; init; }
        public string Descricao {get; init; }
        public string Sigla {get; init; }
    }
}