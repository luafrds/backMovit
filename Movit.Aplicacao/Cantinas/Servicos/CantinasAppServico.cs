using AutoMapper;
using Microsoft.Extensions.Logging;
using Movit.Aplicacao.Cantinas.Servicos.Interfaces;
using Movit.Aplicacao.Transacoes.Interface;
using Movit.DataTransfer.Cantinas.Request;
using Movit.DataTransfer.Cantinas.Response;
using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Repositorios;
using Movit.Dominio.Cantinas.Repositorios.Filtros;
using Movit.Dominio.Cantinas.Servicos.Comandos;
using Movit.Dominio.Cantinas.Servicos.Interfaces;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Cantinas.Servicos
{
    public class CantinasAppServico : ICantinasAppServico
    {
        private readonly ICantinasRepositorio cantinasRepositorio;
        private readonly ICantinasServico cantinasServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CantinasAppServico> logger;

            public CantinasAppServico(ICantinasRepositorio cantinasRepositorio, ICantinasServico cantinasServico, IMapper mapper, IUnitOfWork unitOfWork, ILogger<CantinasAppServico> logger)
        {
            this.cantinasRepositorio = cantinasRepositorio;
            this.cantinasServico = cantinasServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<CantinaResponse> EditarAsync(int id, CantinaRequest request)
        {
            CantinaComando comando = mapper.Map<CantinaComando>(request);
            comando.Id = id;
            try
            {
                unitOfWork.BeginTransaction();
                Cantina cantina = await cantinasServico.EditarAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<CantinaResponse>(cantina);;
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
                Cantina cantina = await cantinasServico.ValidarAsync(id);
                await cantinasRepositorio.ExcluirAsync(cantina);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError("Deu erro", ex);
                throw;
            }
        }
        public async Task<PaginacaoConsulta<CantinaResponse>> ListarAsync(CantinaListarRequest request)
        {
            CantinaListarFiltro filtro = mapper.Map<CantinaListarFiltro>(request);
            IQueryable<Cantina> query = await cantinasRepositorio.FiltrarAsync(filtro);
            PaginacaoConsulta<Cantina> cantinas = cantinasRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            return mapper.Map<PaginacaoConsulta<CantinaResponse>>(cantinas);
        }

        public async Task<CantinaResponse> RecuperarAsync(int id)
        {
            Cantina cantina = await cantinasServico.ValidarAsync(id);
            return mapper.Map<CantinaResponse>(cantina);
        }
    }
}