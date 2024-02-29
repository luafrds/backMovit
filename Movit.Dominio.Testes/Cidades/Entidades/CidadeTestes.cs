using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Excecoes;
using Xunit;

namespace Movit.Dominio.Testes.Cidades.Entidades
{
    public class CidadeTestes
    {
        private readonly Cidade sut;
        private readonly Cidade cidadeValida;

        public CidadeTestes()
        {
            sut = Builder<Cidade>.CreateNew().Build();
            cidadeValida = Builder<Cidade>.CreateNew().Build();
        }

        public class SetDescricaoMetodo : CidadeTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]

            public void Dado_DescricaoNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string descricao)
            {
                sut.Invoking(x => x.SetDescricao(descricao)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dado_DescricaoComMenosDe3Caracteres_Espero_ExcecaoTamanhoInvalido()
            {
                string descricao = "Te";
                Action act = () => sut.SetDescricao(descricao);
                act.Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_DescricaoComMaisDe100Caracteres_Espero_ExcecaoTamanhoInvalido()
            {
                string descricao = new string('A', 101);
                Action act = () => sut.SetDescricao(descricao);
                act.Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_DescricaoValido_Espero_PropriedadesPreenchidas()
            {
                string descricao = "Cidade Teste";
                sut.SetDescricao(descricao);
                sut.Descricao.Should().NotBeNullOrWhiteSpace(descricao);
                sut.Descricao.Should().Be(descricao);
            }
        }

        public class SetEstadoMetodo : CidadeTestes
        {
            [Fact]
            public void Dado_EstadoNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao()
            {
                sut.Invoking(x => x.SetEstado(null)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dado_EstadoValido_Espero_PropriedadePreenchida()
            {
                Estado estado = Builder<Estado>.CreateNew().Build();
                sut.SetEstado(estado);
                sut.Estado.Should().NotBeNull();
                sut.Estado.Should().BeSameAs(estado); 
            }

        }

    }
}