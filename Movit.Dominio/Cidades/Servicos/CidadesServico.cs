using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Repositorios;
using Movit.Dominio.Cidades.Servicos.Comandos;
using Movit.Dominio.Cidades.Servicos.Interfaces;
using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Servicos.Interfaces;
using Movit.Dominio.Excecoes;

namespace Movit.Dominio.Cidades.Servicos
{
    public class CidadesServico : ICidadesServico
    {
        private readonly ICidadesRepositorio cidadesRepositorio;
        private readonly IEstadosServico estadosServico;

        public CidadesServico(ICidadesRepositorio cidadesRepositorio, IEstadosServico estadosServico)
        {
            this.cidadesRepositorio = cidadesRepositorio;
            this.estadosServico = estadosServico;
        }
        public async Task<Cidade> EditarAsync(CidadeComando comando)
        {
            Estado estado = await estadosServico.ValidarAsync(comando.IdEstado); 
            Cidade cidade = await ValidarAsync(comando.Id);
            cidade.SetDescricao(comando.Descricao);
            cidade.SetEstado(estado);

            await cidadesRepositorio.EditarAsync(cidade);
            return cidade;
        }

        public async Task<Cidade> InserirAsync(CidadeComando comando)
        {
            Estado estado = await estadosServico.ValidarAsync(comando.IdEstado); 
            Cidade cidade = new(comando.Descricao, estado);
            await cidadesRepositorio.InserirAsync(cidade);
            return cidade;
        }

        public async Task<Cidade> ValidarAsync(int id)
        {
            Cidade cidade = await cidadesRepositorio.RecuperarAsync(id);
            if(cidade == null)
            throw new RegraDeNegocioExcecao("Cidade não encontrada");
            return cidade;
        }
    }
}