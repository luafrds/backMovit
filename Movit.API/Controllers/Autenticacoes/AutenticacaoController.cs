using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Autenticacoes.Servicos.Interfaces;
using Movit.DataTransfer.Autenticacoes.Request;
using Movit.DataTransfer.Autenticacoes.Response;

namespace Movit.API.Controllers.Autenticacoes
{
    [ApiController]
    [Route("api/autenticacoes")]
    [Authorize]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacoesAppServico autenticacoesAppServico;

        public AutenticacaoController(IAutenticacoesAppServico autenticacoesAppServico)
        {
            this.autenticacoesAppServico = autenticacoesAppServico;
        }

        /// <summary>
        /// Logar Usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("logar")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Logar([FromBody] LoginRequest request)
        {
            var response = await autenticacoesAppServico.LogarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Cadastrar Usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("cadastro")]
        [AllowAnonymous]
        public async Task<ActionResult<CadastroResponse>> CadastrarAsync([FromBody] CadastroRequest request)
        {
            var response = await autenticacoesAppServico.CadastrarAsync(request);
            return Ok(response);
        }
    }
}