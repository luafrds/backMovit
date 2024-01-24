using Movit.Dominio.Util;
using Movit.Dominio.Util.Enumeradores;

namespace Movit.DataTransfer.Estados.Request
{
    public class EstadoListarRequest : PaginacaoFiltro
    {
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public EstadoListarRequest()  : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc){}
    }
}