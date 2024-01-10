using Movit.Dominio.Util;
using Movit.Dominio.Util.Enumeradores;

namespace Movit.DataTransfer.Usuarios.Request
{
    public class UsuarioListarRequest : PaginacaoFiltro
    {
        public string Email { get; set; }
        public int TipoUsuario { get; set; }
        public UsuarioListarRequest()  : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc){}
    }
}