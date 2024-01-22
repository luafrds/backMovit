using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Repositorios;
using Movit.Dominio.Cantinas.Servicos.Comandos;
using Movit.Dominio.Cantinas.Servicos.Interfaces;
using Movit.Dominio.Excecoes;

namespace Movit.Dominio.Cantinas.Servicos
{
    public class CantinasServico : ICantinasServico
    {
        private readonly ICantinasRepositorio cantinasRepositorio;

        public CantinasServico(ICantinasRepositorio cantinasRepositorio)
        {
            this.cantinasRepositorio = cantinasRepositorio;
        }

        public async Task<Cantina> EditarAsync(CantinaComando comando)
        {
            Cantina cantina = await ValidarAsync(comando.Id);
            cantina.SetNomeComida(comando.NomeComida);
            cantina.SetDataCantina(comando.DataCantina);
            cantina.SetValor(comando.Valor);
            cantina.SetQuantidade(comando.Quantidade);
            await cantinasRepositorio.EditarAsync(cantina);
            return cantina;
        }

        public async Task<Cantina> InserirAsync(CantinaComando comando)
        {
            Cantina cantina = new(comando.NomeComida, comando.DataCantina, comando.Valor, comando.Quantidade);
            await cantinasRepositorio.InserirAsync(cantina);
            return cantina;
        }

        public async Task<Cantina> ValidarAsync(int id)
        {
            Cantina cantina = await cantinasRepositorio.RecuperarAsync(id);
            if(cantina == null)
            throw new RegraDeNegocioExcecao("Cantina não encontrada");
            return cantina;
        }
    }
}