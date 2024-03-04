using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Servicos.Interfaces;
using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Eventos.Repositorios;
using Movit.Dominio.Eventos.Servicos;
using Movit.Dominio.Eventos.Servicos.Comandos;
using Movit.Dominio.Excecoes;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Movit.Dominio.Testes.Eventos.Servicos
{
    public class EventosServicoTestes
    {
        private readonly EventosServico sut;
        private readonly IEventosRepositorio eventosRepositorio;
        private readonly ICidadesServico cidadesServico;
        private readonly Evento eventoValido;
        private readonly EventoComando comando;
        private readonly Cidade cidadeValida;

        public EventosServicoTestes()
        {
            eventoValido = Builder<Evento>.CreateNew().Build();
            eventosRepositorio = Substitute.For<IEventosRepositorio>();
            cidadesServico = Substitute.For<ICidadesServico>();
            comando = Builder<EventoComando>.CreateNew()
                                .With(x => x.Titulo, "Titulo Teste")
                                .With(x => x.Cep, "12345678")
                                .With(x => x.Logradouro, "Teste Logradouro")
                                .With(x => x.Numero, "06")
                                .With(x => x.Complemento, "Teste Complemento")
                                .With(x => x.DataEvento, new DateTime(2023, 4, 5))
                                .Build();

            cidadeValida = Builder<Cidade>.CreateNew().Build();

            sut = new EventosServico(eventosRepositorio, cidadesServico);
        }

        public class ValidarAsyncMetodo : EventosServicoTestes
        {
            [Fact]
            public void Dado_EventoNaoEncontrado_Espero_RegraDeNegocioExcecao()
            {
                eventosRepositorio.RecuperarAsync(2).ReturnsNull();
                sut.Invoking(x => x.ValidarAsync(2)).Should().ThrowAsync<RegraDeNegocioExcecao>();
            }

            [Fact]
            public async void Dado_EventoEncontrado_Espero_EventoValido()
            {
                eventosRepositorio.RecuperarAsync(2).Returns(eventoValido);
                Evento resultado = await sut.ValidarAsync(2);
                resultado.Should().BeSameAs(eventoValido);
            }
        }

        public class InserirAsyncMetodo : EventosServicoTestes
        {
            [Fact]
            public async Task Dado_EventoValida_Espero_EventoInserido()
            {
                cidadesServico.ValidarAsync(Arg.Any<int>()).Returns(cidadeValida);

                eventosRepositorio.InserirAsync(Arg.Any<Evento>()).Returns(eventoValido);
                Evento evento = await sut.InserirAsync(comando);

                await eventosRepositorio.Received(1).InserirAsync(Arg.Any<Evento>());
                evento.Should().BeOfType<Evento>();
                evento.Should().NotBeNull();
                evento.Titulo.Should().Be(comando.Titulo);
                evento.DataEvento.Should().Be(comando.DataEvento);
                evento.Cidade.Id.Should().Be(comando.IdCidade);
                evento.Cidade.Should().BeSameAs(cidadeValida);
                evento.Titulo.Should().Be(comando.Titulo);
            }
        }

        public class EditarAsyncMetodo : EventosServicoTestes
        {
            [Fact]
            public async Task Dado_EventoValida_Espero_EventoInserido()
            {
                cidadesServico.ValidarAsync(Arg.Any<int>()).Returns(cidadeValida);
                sut.ValidarAsync(Arg.Any<int>()).Returns(eventoValido);

                eventosRepositorio.EditarAsync(Arg.Any<Evento>()).Returns(eventoValido);
                Evento evento = await sut.EditarAsync(comando);

                await eventosRepositorio.Received(1).EditarAsync(Arg.Any<Evento>());
                evento.Should().BeOfType<Evento>();
                evento.Should().NotBeNull();
                evento.Titulo.Should().Be(comando.Titulo);
                evento.DataEvento.Should().Be(comando.DataEvento);
                evento.Cidade.Id.Should().Be(comando.IdCidade);
                evento.Cidade.Should().BeSameAs(cidadeValida);
                evento.Titulo.Should().Be(comando.Titulo);
            }
        }


    }
}






