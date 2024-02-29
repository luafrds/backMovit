using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Excecoes;
using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Repositorios;
using Movit.Dominio.Membros.Servicos;
using Movit.Dominio.Membros.Servicos.Comandos;
using Movit.Dominio.Usuarios.Servicos.Interfaces;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Movit.Dominio.Testes.Membros.Servicos
{
    public class MembrosServicoTestes
    {
        private readonly MembrosServico sut;
        private readonly IMembrosRepositorio membrosRepositorio;
        private readonly IUsuariosServico usuariosServico;
        private readonly Membro membroValido;
        private readonly MembroComando comando;

        public MembrosServicoTestes()
        {
            membroValido = Builder<Membro>.CreateNew().Build();
            membrosRepositorio = Substitute.For<IMembrosRepositorio>();
            usuariosServico = Substitute.For<IUsuariosServico>();
            comando = Builder<MembroComando>.CreateNew().With(x => x.Email, "teste@gmail.com").Build();

            sut = new MembrosServico(membrosRepositorio, usuariosServico);
        }

        public class ValidarAsyncMetodo : MembrosServicoTestes
        {
            [Fact]
            public void Dado_MembroNaoEncontrado_Espero_RegraDeNegocioExcecao()
            {
                membrosRepositorio.RecuperarAsync(2).ReturnsNull();
                sut.Invoking(x => x.ValidarAsync(2)).Should().ThrowAsync<RegraDeNegocioExcecao>();
            }

            [Fact]
            public async void Dado_MembroEncontrado_Espero_MembroValido()
            {
                membrosRepositorio.RecuperarAsync(2).Returns(membroValido);
                Membro resultado = await sut.ValidarAsync(2);
                resultado.Should().BeSameAs(membroValido);
            }
        }

        public class InserirAsyncMetodo : MembrosServicoTestes
        {
            [Fact]
            public async Task Dado_MembroValido_Espero_MembroInserido()
            {
                Membro resultado = await sut.InserirAsync(comando);
                membrosRepositorio.InserirAsync(resultado).Returns(membroValido);

                resultado.Should().BeOfType<Membro>();
                resultado.Email.Should().Be(comando.Email);
                resultado.NomeCompleto.Should().Be(comando.NomeCompleto);
                resultado.DataNascimento.Should().Be(comando.DataNascimento);
            }
        }

        public class EditarAsyncMetodo : MembrosServicoTestes
        {
            [Fact]
            public async Task Quando_MetodoForChamado_Espero_MembroAtualizado()
            {
                membrosRepositorio.Recuperar(1).Returns(membroValido);

                sut.ValidarAsync(1).Returns(membroValido);
                Membro resultado = await sut.EditarAsync(comando);
                await membrosRepositorio.Received(1).EditarAsync(resultado);
                resultado.Email.Should().Be(comando.Email);
                resultado.NomeCompleto.Should().Be(comando.NomeCompleto);
                resultado.DataNascimento.Should().Be(comando.DataNascimento);
            }
        }
    }
}