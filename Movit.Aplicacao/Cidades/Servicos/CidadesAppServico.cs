using AutoMapper;
using Microsoft.Extensions.Logging;
using Movit.Aplicacao.Cidades.Servicos.Interfaces;
using Movit.Aplicacao.Transacoes.Interface;
using Movit.DataTransfer.Cidades.Request;
using Movit.DataTransfer.Cidades.Response;
using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Repositorios;
using Movit.Dominio.Cidades.Repositorios.Filtros;
using Movit.Dominio.Cidades.Servicos.Comandos;
using Movit.Dominio.Cidades.Servicos.Interfaces;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Cidades.Servicos
{
    public class CidadesAppServico : ICidadesAppServico
    {
        private readonly ICidadesRepositorio cidadesRepositorio;
        private readonly ICidadesServico cidadesServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CidadesAppServico> logger;

        public CidadesAppServico(ICidadesRepositorio cidadesRepositorio, ICidadesServico cidadesServico, IMapper mapper, IUnitOfWork unitOfWork, ILogger<CidadesAppServico> logger)
        {
            this.cidadesRepositorio = cidadesRepositorio;
            this.cidadesServico = cidadesServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<CidadeResponse> EditarAsync(int id, CidadeRequest request)
        {
            CidadeComando comando = mapper.Map<CidadeComando>(request);
            comando.Id = id;
            try
            {
                unitOfWork.BeginTransaction();
                Cidade cidade = await cidadesServico.EditarAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<CidadeResponse>(cidade);
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
                Cidade cidade = await cidadesServico.ValidarAsync(id);
                await cidadesRepositorio.ExcluirAsync(cidade);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<CidadeResponse> InserirAsync(CidadeRequest request)
        {
            var comando = mapper.Map<CidadeComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                var cidade = await cidadesServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<CidadeResponse>(cidade);
            }
            catch(Exception ex)
            {
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<PaginacaoConsulta<CidadeResponse>> ListarAsync(CidadeListarRequest request)
        {
            CidadeListarFiltro filtro = mapper.Map<CidadeListarFiltro>(request);
            IQueryable<Cidade> query = await cidadesRepositorio.FiltrarAsync(filtro);
            PaginacaoConsulta<Cidade> cidades = cidadesRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            return mapper.Map<PaginacaoConsulta<CidadeResponse>>(cidades);
        }

        public async Task<CidadeResponse> RecuperarAsync(int id)
        {
            Cidade cidade = await cidadesServico.ValidarAsync(id);
            return mapper.Map<CidadeResponse>(cidade);
        }
    }
}