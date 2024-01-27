using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Cidades.Servicos.Interfaces;
using Movit.DataTransfer.Cidades.Request;
using Movit.DataTransfer.Cidades.Response;
using Movit.Dominio.Util;

namespace Movit.API.Controllers.Cidades
{
    [ApiController]
    [Route("api/cidades")]
    public class CidadesController: ControllerBase
    {
        private readonly ICidadesAppServico cidadesAppServico;

        public CidadesController(ICidadesAppServico cidadesAppServico)
        {
            this.cidadesAppServico = cidadesAppServico;
        }

        /// <summary>
        /// Recupera uma cidade por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CidadeResponse>> RecuperarAsync(int id)
        {
            var response = await cidadesAppServico.RecuperarAsync(id);

            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        /// Listar cidades
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<CidadeResponse>>> ListarAsync([FromQuery] CidadeListarRequest request)
        {
            var response = await cidadesAppServico.ListarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar uma cidade por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAsync(int id, [FromBody] CidadeRequest request)
        {
            await cidadesAppServico.EditarAsync(id, request);
            return Ok();
        }

        /// <summary>
        /// Excluir uma cidade por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> ExcluirAsync(int id)
        {
            await cidadesAppServico.ExcluirAsync(id);
            return Ok();
        }

        ///<summary>
        /// Criar Cidade.
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public async Task<ActionResult> InserirAsync([FromBody] CidadeRequest request)
        {
            var response = await cidadesAppServico.InserirAsync(request);
            return Ok(response);
        } 

    }
}