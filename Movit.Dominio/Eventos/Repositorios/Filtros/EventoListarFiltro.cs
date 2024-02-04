using Movit.Dominio.Cidades.Entidades;

namespace Movit.Dominio.Eventos.Repositorios.Filtros
{
    public class EventoListarFiltro
    {
        public string Titulo { get; set; }
        public Cidade Cidade { get; set; }
        public  string Logradouro { get; set; }
        public  string Numero { get; set; }
        public  DateTime DataEvento { get; set; }
    }
}