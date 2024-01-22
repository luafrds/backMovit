using AutoMapper;
using Microsoft.Extensions.Logging;
using Movit.Aplicacao.Membros.Servicos.Interfaces;
using Movit.Aplicacao.Transacoes.Interface;
using Movit.DataTransfer.Membros.Request;
using Movit.DataTransfer.Membros.Response;
using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Repositorios;
using Movit.Dominio.Membros.Repositorios.Filtros;
using Movit.Dominio.Membros.Servicos.Comandos;
using Movit.Dominio.Membros.Servicos.Interfaces;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Membros.Servicos
{
    public class MembrosAppServico : IMembrosAppServico
    {
        private readonly IMembrosRepositorio membrosRepositorio;
        private readonly IMembrosServico membrosServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<MembrosAppServico> logger;

        public MembrosAppServico(IMembrosRepositorio membrosRepositorio, IMembrosServico membrosServico, IMapper mapper, IUnitOfWork unitOfWork, ILogger<MembrosAppServico> logger)
        {
            this.membrosRepositorio = membrosRepositorio;
            this.membrosServico = membrosServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<MembroResponse> EditarAsync(int id, MembroRequest request)
        {
            MembroComando comando = mapper.Map<MembroComando>(request);
            comando.Id = id;
            try
            {
                unitOfWork.BeginTransaction();
                Membro membro = await membrosServico.EditarAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<MembroResponse>(membro);;
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
                Membro membro = await membrosServico.ValidarAsync(id);
                await membrosRepositorio.ExcluirAsync(membro);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

        public async Task<PaginacaoConsulta<MembroResponse>> ListarAsync(MembroListarRequest request)
        {
            MembroListarFiltro filtro = mapper.Map<MembroListarFiltro>(request);
            IQueryable<Membro> query = await membrosRepositorio.FiltrarAsync(filtro);
            PaginacaoConsulta<Membro> membros = membrosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            return mapper.Map<PaginacaoConsulta<MembroResponse>>(membros);
        }

        public async Task<MembroResponse> RecuperarAsync(int id)
        {
            Membro membro = await membrosServico.ValidarAsync(id);
            return mapper.Map<MembroResponse>(membro);
        }

        public async Task<MembroResponse> InserirAsync(MembroRequest request)
        {
            var comando = mapper.Map<MembroComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                var membro = await membrosServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<MembroResponse>(membro);
            }
            catch(Exception ex)
            {
                logger.LogError("Deu erro", ex);
                throw;
            }
        }

    }
}