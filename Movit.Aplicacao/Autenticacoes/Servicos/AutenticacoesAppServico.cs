using AutoMapper;
using Movit.Aplicacao.Autenticacoes.Servicos.Interfaces;
using Movit.DataTransfer.Autenticacoes.Request;
using Movit.DataTransfer.Autenticacoes.Response;
using Movit.Dominio.Autenticacoes.Servicos.Interfaces;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Repositorios;
using Movit.Dominio.Usuarios.Servicos.Interfaces;

namespace Movit.Aplicacao.Autenticacoes.Servicos
{
    public class AutenticacoesAppServico : IAutenticacoesAppServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IUsuariosServico usuariosServico;
        private readonly IAutenticacoesServico autenticacoesServico;
        private readonly IMapper mapper;

        public AutenticacoesAppServico(IUsuariosRepositorio usuariosRepositorio, IUsuariosServico usuariosServico, IAutenticacoesServico autenticacoesServico, IMapper mapper)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            this.usuariosServico = usuariosServico;
            this.autenticacoesServico = autenticacoesServico;
            this.mapper = mapper;
        }

        public async Task<CadastroResponse> CadastrarAsync(CadastroRequest request)
        {
            Usuario usuario =  autenticacoesServico.ValidarCadastro(request.Email, request.Senha, request.TipoUsuario);
            usuario.SetSenhaHash(BCrypt.Net.BCrypt.HashPassword(request.Senha));
            usuario = await usuariosRepositorio.InserirAsync(usuario);
            return mapper.Map<CadastroResponse>(usuario);
        }

        public async Task<LoginResponse> LogarAsync(LoginRequest loginRequest)
        {
            var usuario = await usuariosRepositorio.RecuperaUsuarioPorEmailAsync(loginRequest.Email);
            usuario = autenticacoesServico.ValidarLogin(usuario, loginRequest.Senha);

            string token = autenticacoesServico.GerarToken(usuario);

            var response = new LoginResponse();
            response.Token = token;

            return response;
        }
    }
}