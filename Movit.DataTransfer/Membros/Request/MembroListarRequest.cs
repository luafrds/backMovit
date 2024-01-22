using Movit.Dominio.Membros.Enumeradores;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Util;
using Movit.Dominio.Util.Enumeradores;

namespace Movit.DataTransfer.Membros.Request
{
    public class MembroListarRequest : PaginacaoFiltro
    {
        public string  NomeCompleto{ get; set; }
        public DateTime DataNascimento{get; set; }
        public string Email { get; set; }
        public int SituacaoMembro { get; set; }
        public int IdUsuario { get; set; }

        public MembroListarRequest() : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc){}
    }
}