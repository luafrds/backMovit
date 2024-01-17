namespace Movit.DataTransfer.Cantinas.Request
{
    public record CantinaRequest (string NomeComida, DateTime DataCantina,  decimal Valor, int Quantidade);
}
