using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Cantinas.Servicos.Interfaces;
using Movit.DataTransfer.Cantinas.Request;
using Movit.DataTransfer.Cantinas.Response;
using Movit.Dominio.Util;

namespace Movit.API.Controllers.Cantinas
{
    [ApiController]
    [Route("api/usuarios")]
    public class CantinasController : ControllerBase
    {
        private readonly ICantinasAppServico cantinasAppServico;

        public CantinasController(ICantinasAppServico cantinasAppServico)
        {
            this.cantinasAppServico = cantinasAppServico;
        }

        /// <summary>
        /// Recupera um usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CantinaResponse>> RecuperarAsync(int id)
        {
            var response = await cantinasAppServico.RecuperarAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Listar usuarios
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<CantinaResponse>>> ListarAsync([FromQuery] CantinaListarRequest request)
        {
            var response = await cantinasAppServico.ListarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar um usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAsync(int id, [FromBody] CantinaRequest request)
        {
            await cantinasAppServico.EditarAsync(id, request);
            return Ok();
        }

        /// <summary>
        /// Excluir um usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> ExcluirAsync(int id)
        {
            await cantinasAppServico.ExcluirAsync(id);
            return Ok();
        }
        
    }
}