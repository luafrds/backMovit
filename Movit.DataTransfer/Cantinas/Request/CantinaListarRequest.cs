using Movit.Dominio.Util;
using Movit.Dominio.Util.Enumeradores;

namespace Movit.DataTransfer.Cantinas.Request
{
    public class CantinaListarRequest: PaginacaoFiltro
    {
        public string NomeComida { get; set; }
        public DateTime DataCantina { get; set; }
        public decimal Valor{ get; set; }
        public int Quantidade{ get; set; }
        public CantinaListarRequest()  : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc){}
    }
}