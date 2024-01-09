namespace Movit.Dominio.Cantinas.Servicos.Comandos
{
    public class CantinaComando
    {
        public int Id { get; set; }
        public string NomeComida { get; set; }
        public DateTime DataCantina { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}