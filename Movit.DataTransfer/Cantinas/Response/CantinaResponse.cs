namespace Movit.DataTransfer.Cantinas.Response
{
    public record CantinaResponse
    {
        public int Id { get; init; }
        public string NomeComida { get; init; }
        public DateTime DataCantina { get; init; }
        public Decimal Valor { get; init; }
        public int Quantidade {get; init; }
    }
}