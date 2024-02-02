using Movit.Dominio.Util;
using Movit.Dominio.Util.Enumeradores;

namespace Movit.DataTransfer.Eventos.Request
{
    public class EventoListarRequest:  PaginacaoFiltro
    {
        public string Titulo { get; set; }
        public DateTime DataEvento { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int IdCidade { get; internal set; }

        public EventoListarRequest() : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc){}
    }
}