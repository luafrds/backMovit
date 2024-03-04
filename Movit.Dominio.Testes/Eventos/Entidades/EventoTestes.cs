using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Excecoes;
using Xunit;

namespace Movit.Dominio.Testes.Eventos.Entidades
{
    public class EventoTestes
    {
        private readonly Evento sut;
        private readonly Cidade cidadeValida;

        public EventoTestes()
        {
            sut = Builder<Evento>.CreateNew().Build();
            cidadeValida = Builder<Cidade>.CreateNew().Build();
        }

        public class SetTituloMetodo : EventoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]

            public void Dado_TituloNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string titulo)
            {
                sut.Invoking(x => x.SetTitulo(titulo)).Should().Throw<RegraDeNegocioExcecao>();
            }
            public void Dado_TituloCompletoValido_Espero_PropriedadesPreenchidas()
            {
                string titulo = "Titulo Teste";
                sut.SetTitulo(titulo);
                sut.Titulo.Should().NotBeNullOrWhiteSpace(titulo);
                sut.Titulo.Should().Be(titulo);
            }
        }

        public class SetDataEventoMetodo : EventoTestes
        {
            [Fact]
            public void Dado_DataEvento_Preenchido_Espero_PropriedadeSetada()
            {
                DateTime dataEvento = new DateTime(2024, 3, 1);
                sut.SetDataEvento(dataEvento);
                Assert.Equal(dataEvento, sut.DataEvento);
            }
            
            [Fact]
            public void Quando_TentarInserirDataMinima_DeveLancarExcecao()
            {
                Assert.Throws<AtributoInvalidoExcecao>(() => sut.SetDataEvento(DateTime.MinValue));
            }

         }

        public class SetCepMetodo : EventoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]

            public void Dado_CepNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string cep)
            {
                sut.Invoking(x => x.SetCep(cep)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Theory]
            [InlineData("29104-4600")]
            [InlineData("291044")]
            public void Dado_CepTiverTamanhoInvalido_Espero_Excecao(string cep)
            {
                sut.Invoking(s => s.SetCep(cep)).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Theory]
            [InlineData("29104-46s")]
            [InlineData("29104-   ")]
            public void Dado_CepConterCaracteresEspeciaisETiverFormatoInvalido_Espero_Excecao(string cep)
            {
                sut.Invoking(s => s.SetCep(cep)).Should().Throw<AtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_CepValido_Espero_PropriedadePreenchida()
            {
                var cep = "29104460";
                sut.SetCep(cep);
                sut.Cep.Should().Be(cep);
            }
        }

        public class SetLogradouroMetodo : EventoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]

            public void Dado_LogradouroNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string logradouro)
            {
                sut.Invoking(x => x.SetLogradouro(logradouro)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dado_LogradouroMaiorQueCinquentaCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(s => s.SetLogradouro(new string('*', 51))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Quando_LogradouroForValido_Espero_PropriedadePreenchida()
            {
                var logradouro = "Rua teste";
                sut.SetLogradouro(logradouro);
                sut.Logradouro.Should().Be(logradouro);
            }
        }

        public class SetCidadeMetodo : EventoTestes
        {
           [Fact]
            public void Dado_UsuarioNulo_Espero_AtributoObrigatorioExcecao()
            {
                sut.Invoking(x => x.SetCidade(null)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dado_CidadeValida_EsperoPropriedadesPreenchidas()
            {
                sut.SetCidade(cidadeValida);
                sut.Cidade.Should().Be(cidadeValida);
            }

        }

        public class SetNumeroMetodo : EventoTestes
        {
            [Fact]
            public void Dado_NumeroMaiorQueSeisCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(s => s.SetNumero(new string('*', 7))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_NumeroValido_Espero_PropriedadePreenchida()
            {
                var numero = "123456";
                sut.SetNumero(numero);
                sut.Numero.Should().Be(numero);
            }
        }

        public class SetCoplementoMetodo : EventoTestes
        {
            [Fact]
            public void Dado_ComplementoMaiorQueCinquentaCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(s => s.SetComplemento(new string('*', 51))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_ComplementoValido_Espero_PropriedadePreenchida()
            {
                var complemento = "Complemento teste";
                sut.SetComplemento(complemento);
                sut.Complemento.Should().Be(complemento);
            }
        }

    }
}