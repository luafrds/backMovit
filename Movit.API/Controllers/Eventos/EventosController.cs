using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Eventos.Servicos.Interfaces;
using Movit.DataTransfer.Eventos.Request;
using Movit.DataTransfer.Eventos.Response;
using Movit.Dominio.Util;

namespace Movit.API.Controllers.Eventos
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosController: ControllerBase
    {
        private readonly IEventosAppServico eventosAppServico;

        public EventosController(IEventosAppServico eventosAppServico)
        {
            this.eventosAppServico = eventosAppServico;
        }

        /// <summary>
        /// Recupera um evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoResponse>> RecuperarAsync(int id)
        {
            var response = await eventosAppServico.RecuperarAsync(id);

            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        /// Listar eventos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<EventoResponse>>> ListarAsync([FromQuery] EventoListarRequest request)
        {
            var response = await eventosAppServico.ListarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar um evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAsync(int id, [FromBody] EventoRequest request)
        {
            await eventosAppServico.EditarAsync(id, request);
            return Ok();
        }

        /// <summary>
        /// Excluir um evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> ExcluirAsync(int id)
        {
            await eventosAppServico.ExcluirAsync(id);
            return Ok();
        }

        ///<summary>
        /// Criar evento.
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public async Task<ActionResult> InserirAsync([FromBody] EventoRequest request)
        {
            var response = await eventosAppServico.InserirAsync(request);
            return Ok(response);
        } 



    }
}