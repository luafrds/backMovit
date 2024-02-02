using AutoMapper;
using Microsoft.Extensions.Logging;
using Movit.Aplicacao.Eventos.Servicos.Interfaces;
using Movit.Aplicacao.Transacoes.Interface;
using Movit.DataTransfer.Eventos.Request;
using Movit.DataTransfer.Eventos.Response;
using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Eventos.Repositorios;
using Movit.Dominio.Eventos.Repositorios.Filtros;
using Movit.Dominio.Eventos.Servicos.Comandos;
using Movit.Dominio.Eventos.Servicos.Interfaces;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Eventos.Servicos
{
    public class EventosAppServico : IEventosAppServico
    {
        private readonly IEventosRepositorio eventosRepositorio;
        private readonly IEventosServico eventosServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<EventosAppServico> logger;

        public EventosAppServico(IEventosRepositorio eventosRepositorio, IEventosServico eventosServico, IMapper mapper, IUnitOfWork unitOfWork, ILogger<EventosAppServico> logger)
        {
            this.eventosRepositorio = eventosRepositorio;
            this.eventosServico = eventosServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<EventoResponse> EditarAsync(int id, EventoRequest request)
        {
            EventoComando comando = mapper.Map<EventoComando>(request);
            comando.Id = id;
            try
            {
                unitOfWork.BeginTransaction();
                Evento evento = await eventosServico.EditarAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<EventoResponse>(evento);;
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
                Evento evento = await eventosServico.ValidarAsync(id);
                await eventosRepositorio.ExcluirAsync(evento);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<EventoResponse> InserirAsync(EventoRequest request)
        {
            var comando = mapper.Map<EventoComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                var evento = await eventosServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<EventoResponse>(evento);
            }
            catch(Exception ex)
            {
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<PaginacaoConsulta<EventoResponse>> ListarAsync(EventoListarRequest request)
        {
            EventoListarFiltro filtro = mapper.Map<EventoListarFiltro>(request);
            IQueryable<Evento> query = await eventosRepositorio.FiltrarAsync(filtro);
            PaginacaoConsulta<Evento> eventos = eventosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            return mapper.Map<PaginacaoConsulta<EventoResponse>>(eventos);
        }

        public async Task<EventoResponse> RecuperarAsync(int id)
        {
            Evento evento = await eventosServico.ValidarAsync(id);
            return mapper.Map<EventoResponse>(evento);
        }
    }
}