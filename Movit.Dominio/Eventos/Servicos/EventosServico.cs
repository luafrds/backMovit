using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Servicos.Interfaces;
using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Eventos.Repositorios;
using Movit.Dominio.Eventos.Servicos.Comandos;
using Movit.Dominio.Eventos.Servicos.Interfaces;
using Movit.Dominio.Excecoes;

namespace Movit.Dominio.Eventos.Servicos
{
    public class EventosServico : IEventosServico
    {
        private readonly IEventosRepositorio eventosRepositorio;
        private readonly ICidadesServico cidadesServico;

        public EventosServico(IEventosRepositorio eventosRepositorio, ICidadesServico cidadesServico)
        {
            this.eventosRepositorio = eventosRepositorio;
            this.cidadesServico = cidadesServico;
        }

        public async Task<Evento> EditarAsync(EventoComando comando)
        {
            Cidade cidade = await cidadesServico.ValidarAsync(comando.IdCidade);
            Evento evento = await ValidarAsync(comando.Id);
            evento.SetTitulo(comando.Titulo);
            evento.SetDataEvento(comando.DataEvento);
            evento.SetCep(comando.Cep);
            evento.SetLogradouro(comando.Logradouro);
            evento.SetCidade(cidade);
            evento.SetNumero(comando.Numero);
            evento.SetComplemento(comando.Complemento);

            await eventosRepositorio.EditarAsync(evento);
            return evento;
        }

        public async Task<Evento> InserirAsync(EventoComando comando)
        {
            Cidade cidade = await cidadesServico.ValidarAsync(comando.IdCidade); 
            Evento evento = new(comando.Titulo, comando.DataEvento, comando.Cep, comando.Logradouro, cidade, comando.Numero, comando.Complemento);
            await eventosRepositorio.InserirAsync(evento);
            return evento;
        }

        public async Task<Evento> ValidarAsync(int id)
        {
            Evento evento = await eventosRepositorio.RecuperarAsync(id);
            if(evento == null)
            throw new RegraDeNegocioExcecao("Evento não encontrado");
            return evento;
        }
    }
}