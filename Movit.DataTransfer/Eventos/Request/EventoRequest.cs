namespace Movit.DataTransfer.Eventos.Request
{
    public record EventoRequest (string Titulo, DateTime DataEvento, string Cep, string Logradouro, string Numero, string Complemento, int IdCidade);
}