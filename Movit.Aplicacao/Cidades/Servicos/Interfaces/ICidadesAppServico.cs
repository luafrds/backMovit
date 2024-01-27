using Movit.DataTransfer.Cidades.Request;
using Movit.DataTransfer.Cidades.Response;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Cidades.Servicos.Interfaces
{
    public interface ICidadesAppServico
    {
        Task<CidadeResponse> RecuperarAsync(int id);
        Task<PaginacaoConsulta<CidadeResponse>> ListarAsync(CidadeListarRequest request);
        Task<CidadeResponse> EditarAsync(int id, CidadeRequest request);
        Task ExcluirAsync(int id);
        Task<CidadeResponse> InserirAsync(CidadeRequest request);
    }
}