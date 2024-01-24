using AutoMapper;
using Microsoft.Extensions.Logging;
using Movit.Aplicacao.Estados.Servicos.Interfaces;
using Movit.Aplicacao.Transacoes.Interface;
using Movit.DataTransfer.Estados.Request;
using Movit.DataTransfer.Estados.Response;
using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Repositorios;
using Movit.Dominio.Estados.Repositorios.Filtros;
using Movit.Dominio.Estados.Servicos.Comandos;
using Movit.Dominio.Estados.Servicos.Interfaces;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Estados.Servicos
{
    public class EstadosAppServico : IEstadosAppServico
    {
        private readonly IEstadosRepositorio estadosRepositorio;
        private readonly IEstadosServico estadosServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<EstadosAppServico> logger;

        public EstadosAppServico(IEstadosRepositorio estadosRepositorio, IEstadosServico estadosServico, IMapper mapper, IUnitOfWork unitOfWork, ILogger<EstadosAppServico> logger)
        {
            this.estadosRepositorio = estadosRepositorio;
            this.estadosServico = estadosServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<EstadoResponse> EditarAsync(int id, EstadoRequest request)
        {
            EstadoComando comando = mapper.Map<EstadoComando>(request);
            comando.Id = id;
            try
            {
                unitOfWork.BeginTransaction();
                Estado estado = await estadosServico.EditarAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<EstadoResponse>(estado);
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
                Estado estado = await estadosServico.ValidarAsync(id);
                await estadosRepositorio.ExcluirAsync(estado);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<EstadoResponse> InserirAsync(EstadoRequest request)
        {
            var comando = mapper.Map<EstadoComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                var estado = await estadosServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<EstadoResponse>(estado);
            }
            catch(Exception ex)
            {
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<PaginacaoConsulta<EstadoResponse>> ListarAsync(EstadoListarRequest request)
        {
            EstadoListarFiltro filtro = mapper.Map<EstadoListarFiltro>(request);
            IQueryable<Estado> query = await estadosRepositorio.FiltrarAsync(filtro);
            PaginacaoConsulta<Estado> estados = estadosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            return mapper.Map<PaginacaoConsulta<EstadoResponse>>(estados);
        }

        public async Task<EstadoResponse> RecuperarAsync(int id)
        {
            Estado estado = await estadosServico.ValidarAsync(id);
            return mapper.Map<EstadoResponse>(estado);
        }
    }
}