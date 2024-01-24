using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Estados.Servicos.Interfaces;
using Movit.DataTransfer.Estados.Request;
using Movit.DataTransfer.Estados.Response;
using Movit.Dominio.Util;

namespace Movit.API.Controllers.Estados
{
    [Route("[controller]")]
    public class EstadosController : ControllerBase
    { 
        private readonly IEstadosAppServico estadosAppServico;
        public EstadosController(IEstadosAppServico estadosAppServico)
        {
            this.estadosAppServico = estadosAppServico;
        }

        /// <summary>
        /// Recupera um Estado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoResponse>> RecuperarAsync(int id)
        {
            var response = await estadosAppServico.RecuperarAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Listar Estados
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<EstadoResponse>>> ListarAsync([FromQuery] EstadoListarRequest request)
        {
            var response = await estadosAppServico.ListarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar um Estado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAsync(int id, [FromBody] EstadoRequest request)
        {
            await estadosAppServico.EditarAsync(id, request);
            return Ok();
        }

        /// <summary>
        /// Excluir um Estado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> ExcluirAsync(int id)
        {
            await estadosAppServico.ExcluirAsync(id);
            return Ok();
        }

        ///<summary>
        /// Criar Estado.
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public async Task<ActionResult> InserirAsync([FromBody] EstadoRequest request)
        {
            var response = await estadosAppServico.InserirAsync(request);
            return Ok(response);
        } 
    }
}