using Movit.Dominio.Util;
using Movit.Dominio.Util.Enumeradores;

namespace Movit.DataTransfer.Cidades.Request
{
    public class CidadeListarRequest: PaginacaoFiltro
    {
        public string  Descricao{ get; set; }
        public int IdEstado { get; set; }
        public CidadeListarRequest() : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc){}
    }
}