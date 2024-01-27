using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Membros.Servicos.Interfaces;
using Movit.DataTransfer.Membros.Request;
using Movit.DataTransfer.Membros.Response;
using Movit.Dominio.Util;

namespace Movit.API.Controllers.Membros
{
    [ApiController]
    [Route("api/membros")]
    public class MembrosController: ControllerBase
    {
        private readonly IMembrosAppServico membrosAppServico;

        public MembrosController(IMembrosAppServico membrosAppServico)
        {
            this.membrosAppServico = membrosAppServico;
        }
        /// <summary>
        /// Recupera um membro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MembroResponse>> RecuperarAsync(int id)
        {
            var response = await membrosAppServico.RecuperarAsync(id);

            if (response == null)
                return NotFound();
            return Ok(response);
        }
        
        /// <summary>
        /// Listar membros
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<MembroResponse>>> ListarAsync([FromQuery] MembroListarRequest request)
        {
            var response = await membrosAppServico.ListarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar um membro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAsync(int id, [FromBody] MembroRequest request)
        {
            await membrosAppServico.EditarAsync(id, request);
            return Ok();
        }

        /// <summary>
        /// Excluir um membro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> ExcluirAsync(int id)
        {
            await membrosAppServico.ExcluirAsync(id);
            return Ok();
        }

        ///<summary>
        /// Criar Membro.
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public async Task<ActionResult> InserirAsync([FromBody] MembroRequest request)
        {
            var response = await membrosAppServico.InserirAsync(request);
            return Ok(response);
        } 
    }
}