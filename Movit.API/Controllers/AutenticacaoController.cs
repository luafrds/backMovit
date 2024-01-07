using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movit.Aplicacao.Autenticacoes.Servicos.Interfaces;
using Movit.DataTransfer.Autenticacoes.Request;
using Movit.DataTransfer.Autenticacoes.Response;

namespace Movit.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacoesAppServico autenticacoesAppServico;

        public AutenticacaoController(IAutenticacoesAppServico autenticacoesAppServico)
        {
            this.autenticacoesAppServico = autenticacoesAppServico;
        }

        [HttpPost("logar")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Logar([FromBody] LoginRequest loginRequest)
        {

            var response = await autenticacoesAppServico.LogarAsync(loginRequest);

            return Ok(response);
        }

        [HttpPost("cadastro")]
        [AllowAnonymous]
        public async Task<ActionResult<CadastroResponse>> CadastrarAsync([FromBody] CadastroRequest cadastroRequest)
        {
            var response = await autenticacoesAppServico.CadastrarAsync(cadastroRequest);

            return Ok(response);
        }
    }
}