using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Usuarios.Servicos.Interfaces;
using Movit.DataTransfer.Usuarios.Request;
using Movit.DataTransfer.Usuarios.Response;
using Movit.Dominio.Util;

namespace Movit.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAppServico usuariosAppServico;

        public UsuariosController(IUsuariosAppServico usuariosAppServico)
        {
            this.usuariosAppServico = usuariosAppServico;
        }

        /// <summary>
        /// Recupera um usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponse>> RecuperarAsync(int id)
        {
            var response = await usuariosAppServico.RecuperarAsync(id);

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
        public async Task<ActionResult<PaginacaoConsulta<UsuarioResponse>>> ListarAsync([FromQuery] UsuarioListarRequest request)
        {
            var response = await usuariosAppServico.ListarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar um usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAsync(int id, [FromBody] UsuarioRequest request)
        {
            await usuariosAppServico.EditarAsync(id, request);
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
            await usuariosAppServico.ExcluirAsync(id);
            return Ok();
        }
    }
}