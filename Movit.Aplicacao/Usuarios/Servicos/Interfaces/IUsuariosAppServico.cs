using Movit.DataTransfer.Usuarios.Request;
using Movit.DataTransfer.Usuarios.Response;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosAppServico
    {
        Task<UsuarioResponse> RecuperarAsync(int id);
        Task<PaginacaoConsulta<UsuarioResponse>> ListarAsync(UsuarioListarRequest request);
        Task<UsuarioResponse> EditarAsync(int id, UsuarioRequest request);
        Task ExcluirAsync(int id);
    }
}