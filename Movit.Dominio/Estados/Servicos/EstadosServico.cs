using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Repositorios;
using Movit.Dominio.Estados.Servicos.Comandos;
using Movit.Dominio.Estados.Servicos.Interfaces;
using Movit.Dominio.Excecoes;

namespace Movit.Dominio.Estados.Servicos
{ 
     public class EstadosServico : IEstadosServico
        {    
        private readonly IEstadosRepositorio estadosRepositorio;

        public EstadosServico(IEstadosRepositorio estadosRepositorio)
        {
            this.estadosRepositorio = estadosRepositorio;
        }

        public async Task<Estado> EditarAsync(EstadoComando comando)
        {
            Estado estado = await ValidarAsync(comando.Id);
            estado.SetDescricao(comando.Descricao);
            estado.SetSigla(comando.Sigla);
            await estadosRepositorio.EditarAsync(estado);
            return estado;
        }

        public async Task<Estado> InserirAsync(EstadoComando comando)
        {
            Estado estado = new(comando.Descricao, comando.Sigla);
            await estadosRepositorio.InserirAsync(estado);
            return estado;
        }

        public async Task<Estado> ValidarAsync(int id)
        {
            Estado estado = await estadosRepositorio.RecuperarAsync(id);
            if(estado == null)
            throw new RegraDeNegocioExcecao("Estado não encontrada");
            return estado;
        }
    }
}