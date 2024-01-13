using AutoMapper;
using Microsoft.Extensions.Logging;
using Movit.Aplicacao.Transacoes.Interface;
using Movit.Aplicacao.Usuarios.Servicos.Interfaces;
using Movit.DataTransfer.Usuarios.Request;
using Movit.DataTransfer.Usuarios.Response;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Repositorios;
using Movit.Dominio.Usuarios.Repositorios.Filtros;
using Movit.Dominio.Usuarios.Servicos.Comandos;
using Movit.Dominio.Usuarios.Servicos.Interfaces;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IUsuariosServico usuariosServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UsuariosAppServico> logger;

        public UsuariosAppServico(IUsuariosRepositorio usuariosRepositorio, IUsuariosServico usuariosServico, IMapper mapper, IUnitOfWork unitOfWork, ILogger<UsuariosAppServico> logger)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            this.usuariosServico = usuariosServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<UsuarioResponse> EditarAsync(int id, UsuarioRequest request)
        {
            UsuarioComando comando = mapper.Map<UsuarioComando>(request);
            comando.Id = id;
            try
            {
                unitOfWork.BeginTransaction();
                Usuario usuario = await usuariosServico.EditarAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<UsuarioResponse>(usuario);;
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Usuario usuario = await usuariosServico.ValidarAsync(id);
                await usuariosRepositorio.ExcluirAsync(usuario);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<PaginacaoConsulta<UsuarioResponse>> ListarAsync(UsuarioListarRequest request)
        {
            UsuarioListarFiltro filtro = mapper.Map<UsuarioListarFiltro>(request);
            IQueryable<Usuario> query = await usuariosRepositorio.FiltrarAsync(filtro);
            PaginacaoConsulta<Usuario> usuarios = usuariosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            return mapper.Map<PaginacaoConsulta<UsuarioResponse>>(usuarios);
        }

        public async Task<UsuarioResponse> RecuperarAsync(int id)
        {
            Usuario usuario = await usuariosServico.ValidarAsync(id);
            return mapper.Map<UsuarioResponse>(usuario);
        }
    }
}